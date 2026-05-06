using System.Text.Json;
using SolarBackend.Models;

namespace SolarBackend.Services;

public sealed class CatalogRepository
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private readonly IReadOnlyList<ServiceOffering> _services;
    private readonly IReadOnlyList<ProjectCaseStudy> _projects;
    private readonly CompanyProfile _companyProfile;

    public CatalogRepository(IHostEnvironment environment)
    {
        var seedRoot = Path.Combine(environment.ContentRootPath, "Data", "seed");
        _companyProfile = ReadJsonFile<CompanyProfile>(Path.Combine(seedRoot, "company.json"));
        _services = ReadJsonFile<List<ServiceOffering>>(Path.Combine(seedRoot, "services.json"));
        _projects = ReadJsonFile<List<ProjectCaseStudy>>(Path.Combine(seedRoot, "projects.json"));
    }

    public CompanyProfile GetCompanyProfile() => _companyProfile;

    public IReadOnlyList<ServiceOffering> GetServices(string? category = null)
    {
        if (string.IsNullOrWhiteSpace(category))
        {
            return _services;
        }

        return _services
            .Where(service => string.Equals(service.Category, category, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public IReadOnlyList<ProjectCaseStudy> GetProjects() => _projects;

    private static T ReadJsonFile<T>(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Seed data file not found: {filePath}");
        }

        var rawJson = File.ReadAllText(filePath);
        var deserialized = JsonSerializer.Deserialize<T>(rawJson, JsonOptions);

        if (deserialized is null)
        {
            throw new InvalidDataException($"Failed to deserialize seed data file: {filePath}");
        }

        return deserialized;
    }
}
