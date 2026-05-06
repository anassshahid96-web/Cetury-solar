using SolarBackend.Models;

namespace SolarBackend.Services;

public sealed class QuoteService
{
    private readonly QuoteRepository _quoteRepository;
    private readonly QuoteEstimator _quoteEstimator;

    public QuoteService(QuoteRepository quoteRepository, QuoteEstimator quoteEstimator)
    {
        _quoteRepository = quoteRepository;
        _quoteEstimator = quoteEstimator;
    }

    public async Task<QuoteLead> CreateLeadAsync(QuoteRequest request, CancellationToken cancellationToken = default)
    {
        var estimate = _quoteEstimator.Estimate(request.MonthlyBillPkr);

        var lead = new QuoteLead
        {
            Id = Guid.NewGuid().ToString("N"),
            CreatedAtUtc = DateTime.UtcNow,
            PhoneNumber = request.PhoneNumber,
            MonthlyBillPkr = request.MonthlyBillPkr,
            Name = request.Name,
            Email = request.Email,
            Notes = request.Notes,
            EstimatedMonthlySavingsPkr = estimate.EstimatedMonthlySavingsPkr,
            EstimatedRoiYears = estimate.EstimatedRoiYears,
            EstimatedSystemSizeKw = estimate.EstimatedSystemSizeKw
        };

        return await _quoteRepository.AddAsync(lead, cancellationToken);
    }

    public async Task<IReadOnlyList<QuoteLead>> GetRecentLeadsAsync(int limit = 50, CancellationToken cancellationToken = default)
    {
        var safeLimit = Math.Clamp(limit, 1, 200);
        var leads = await _quoteRepository.GetAllAsync(cancellationToken);
        return leads
            .OrderByDescending(lead => lead.CreatedAtUtc)
            .Take(safeLimit)
            .ToList();
    }
}
