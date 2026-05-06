namespace SolarBackend.Models;

public sealed class QuoteEstimate
{
    public decimal EstimatedSystemSizeKw { get; init; }
    public decimal EstimatedMonthlySavingsPkr { get; init; }
    public decimal EstimatedRoiYears { get; init; }
}
