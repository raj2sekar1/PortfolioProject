using Portfolio.Core.DTOs;
using Portfolio.DB.Repositories;
using static Portfolio.Core.Constants;

namespace Portfolio.Service.Concretes;

public class PerformanceService(
    IPortfolioRepository portfolioRepository) : IPerformanceService
{
    public PerformanceResultDto GetPerformance(int portfolioId, DateTime from, DateTime to)
    {
        var portfolio = portfolioRepository.GetById(portfolioId);
        if (portfolio == null) return new();

        decimal totalValue = 0;
        decimal realizedGain = 0;
        decimal unrealizedGain = 0;
        var allocation = new Dictionary<string, decimal>();

        foreach (var asset in portfolio.Assets)
        {
            decimal holdings = 0;
            decimal cost = 0;
            decimal proceeds = 0;
            decimal costBasis = 0;

            foreach (var tx in asset.Transactions.Where(t => from <= t.Date && t.Date <= to))
            {
                if (tx.Type == TransactionTypeConstants.TYPE_BUY)
                {
                    holdings += tx.Quantity;
                    cost += tx.Quantity * tx.Price;
                }
                else if (tx.Type == TransactionTypeConstants.TYPE_SELL)
                {
                    holdings -= tx.Quantity;
                    proceeds += tx.Quantity * tx.Price;
                    costBasis += tx.Quantity * tx.Price; // naive
                }
            }

            decimal currentValue = holdings * MockMarketConstants.PRICES.GetValueOrDefault(asset.Symbol, 0);
            decimal unrealized = currentValue - (cost - costBasis);

            totalValue += currentValue;
            realizedGain += proceeds - costBasis;
            unrealizedGain += unrealized;

            allocation[asset.Symbol] = currentValue;
        }

        var allocationPercent = allocation.ToDictionary(kv => kv.Key, kv => Math.Round(kv.Value / totalValue * 100, 2));

        return new PerformanceResultDto
        {
            TotalValue = totalValue,
            Allocation = allocationPercent,
            RealizedGain = realizedGain,
            UnrealizedGain = unrealizedGain
        };
    }
}
