namespace Portfolio.Core.DTOs;

public record TransactionDto(DateTime Date, string Type, int Quantity, decimal Price);
