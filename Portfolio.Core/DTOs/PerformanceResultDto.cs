namespace Portfolio.Core.DTOs;

public record PerformanceResultDto
{
    public decimal TotalValue { get; init; }
    public Dictionary<string, decimal> Allocation { get; init; } = [];
    public decimal RealizedGain { get; init; }
    public decimal UnrealizedGain { get; init; }
}
