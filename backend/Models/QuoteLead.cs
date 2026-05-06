namespace SolarBackend.Models;

public sealed class QuoteLead
{
    public required string Id { get; init; }
    public required DateTime CreatedAtUtc { get; init; }
    public required string PhoneNumber { get; init; }
    public decimal MonthlyBillPkr { get; init; }
    public decimal EstimatedSystemSizeKw { get; init; }
    public decimal EstimatedMonthlySavingsPkr { get; init; }
    public decimal EstimatedRoiYears { get; init; }
    public string? Name { get; init; }
    public string? Email { get; init; }
    public string? Notes { get; init; }
}
