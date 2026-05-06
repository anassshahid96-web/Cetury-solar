using System.Text.Json;
using SolarBackend.Models;

namespace SolarBackend.Services;

public sealed class QuoteRepository
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        WriteIndented = true
    };

    private readonly SemaphoreSlim _mutex = new(1, 1);
    private readonly string _quotesFilePath;

    public QuoteRepository(IHostEnvironment environment)
    {
        _quotesFilePath = Path.Combine(environment.ContentRootPath, "Data", "runtime", "quotes.json");
        EnsureStoreExists();
    }

    public async Task<IReadOnlyList<QuoteLead>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        await _mutex.WaitAsync(cancellationToken);
        try
        {
            return await ReadUnsafeAsync(cancellationToken);
        }
        finally
        {
            _mutex.Release();
        }
    }

    public async Task<QuoteLead> AddAsync(QuoteLead lead, CancellationToken cancellationToken = default)
    {
        await _mutex.WaitAsync(cancellationToken);
        try
        {
            var existing = await ReadUnsafeAsync(cancellationToken);
            var mutable = existing.ToList();
            mutable.Add(lead);

            await using var stream = File.Open(_quotesFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
            await JsonSerializer.SerializeAsync(stream, mutable, JsonOptions, cancellationToken);
            return lead;
        }
        finally
        {
            _mutex.Release();
        }
    }

    private async Task<IReadOnlyList<QuoteLead>> ReadUnsafeAsync(CancellationToken cancellationToken)
    {
        await using var stream = File.Open(_quotesFilePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        var items = await JsonSerializer.DeserializeAsync<List<QuoteLead>>(stream, JsonOptions, cancellationToken);
        return items ?? [];
    }

    private void EnsureStoreExists()
    {
        var directory = Path.GetDirectoryName(_quotesFilePath);
        if (!string.IsNullOrWhiteSpace(directory))
        {
            Directory.CreateDirectory(directory);
        }

        if (!File.Exists(_quotesFilePath))
        {
            File.WriteAllText(_quotesFilePath, "[]");
        }
    }
}
