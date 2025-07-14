using Portfolio.DB.Entities;
using Portfolio.DB.Repositories;
using Portfolio.Service.Concretes;
using static Portfolio.Core.Constants;

namespace Portfolio.Test.Services;

public class PerformanceServiceTests
{
    [Fact]
    public void When_GetPerformance_Called_ShouldReturnCorrectMetrics()
    {
        //arrange
        var repo = new InMemoryPortfolioRepository();
        var portfolio = new EntityPortfolio { Name = "Growth Fund" };
        var asset = new EntityAsset { Symbol = AssetSymbolConstants.SYMBOL_1, Type = AssetTypeConstants.TYPE_1 };

        asset.Transactions.Add(new EntityTransaction
        {
            Date = new DateTime(2024, 01, 01),
            Type = TransactionTypeConstants.TYPE_BUY,
            Quantity = 10,
            Price = 150m
        });
        asset.Transactions.Add(new EntityTransaction
        {
            Date = new DateTime(2024, 06, 01),
            Type = TransactionTypeConstants.TYPE_SELL,
            Quantity = 5,
            Price = 180m
        });

        portfolio.Assets.Add(asset);
        repo.Add(portfolio);

        //act
        var service = new PerformanceService(repo);
        var result = service.GetPerformance(portfolio.Id, new DateTime(2024, 01, 01), DateTime.UtcNow);

        //assert
        Assert.True(result.TotalValue > 0);
        Assert.Single(result.Allocation);
        Assert.Equal(0, result.RealizedGain);
        Assert.True(result.UnrealizedGain > 0);
    }
}
