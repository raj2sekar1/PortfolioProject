namespace Portfolio.DB.Entities;

public record EntityPortfolio
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public List<EntityAsset> Assets { get; init; } = [];
}
