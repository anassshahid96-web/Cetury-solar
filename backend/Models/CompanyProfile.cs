namespace SolarBackend.Models;

public sealed class CompanyProfile
{
    public required string Name { get; init; }
    public required string Tagline { get; init; }
    public required string PhoneNumber { get; init; }
    public required string Address { get; init; }
    public required string OperationalHours { get; init; }
    public required string CoverageCity { get; init; }
    public required int SuccessfulProjects { get; init; }
    public required int Installations { get; init; }
    public required double UptimePercentage { get; init; }
    public required DateTime UpdatedAtUtc { get; init; }
}
