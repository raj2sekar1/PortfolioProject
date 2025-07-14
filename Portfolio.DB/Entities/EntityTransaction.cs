namespace Portfolio.DB.Entities;

public record EntityTransaction
{
    public DateTime Date { get; init; }
    public string Type { get; init; } = string.Empty; // Buy/Sell
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}
