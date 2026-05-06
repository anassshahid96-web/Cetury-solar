namespace SolarBackend.Models;

public sealed class ProjectCaseStudy
{
    public required string Id { get; init; }
    public required string Category { get; init; }
    public required string Title { get; init; }
    public required string Location { get; init; }
    public required string Capacity { get; init; }
    public required string KeyBenefit { get; init; }
    public required string Description { get; init; }
    public required string ImageUrl { get; init; }
    public required DateOnly CompletedOn { get; init; }
    public bool Featured { get; init; }
}
