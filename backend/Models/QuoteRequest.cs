namespace SolarBackend.Models;

public sealed class QuoteRequest
{
    public string? Name { get; init; }
    public string? Email { get; init; }
    public string? Notes { get; init; }
    public required string PhoneNumber { get; init; }
    public decimal MonthlyBillPkr { get; init; }
}
