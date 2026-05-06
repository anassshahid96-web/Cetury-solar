namespace SolarBackend.Models;

public sealed class ServiceOffering
{
    public required string Id { get; init; }
    public required string Category { get; init; }
    public required string Title { get; init; }
    public required string ShortDescription { get; init; }
    public required string LongDescription { get; init; }
    public required string Icon { get; init; }
    public required IReadOnlyList<string> Highlights { get; init; }
    public bool Featured { get; init; }
}
