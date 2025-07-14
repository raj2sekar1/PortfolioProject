namespace Portfolio.DB.Entities;

public record EntityAsset
{
    public int Id { get; init; }
    public string Symbol { get; init; } = string.Empty;
    public string Type { get; init; } = string.Empty;
    public List<EntityTransaction> Transactions { get; init; } = [];
}
