using Portfolio.DB.Entities;
using Portfolio.DB.Repositories;
using Portfolio.Service.Concretes;
using static Portfolio.Core.Constants;

namespace Portfolio.Test.Services;

public class TransactionServiceTest
{
    [Fact]
    public void When_AddTransaction_Called_Return_Success()
    {
        //arrange
        var repo = new InMemoryPortfolioRepository();
        var portfolioService = new PortfolioService(repo);
        var portfolio = portfolioService.Create("Test Portfolio");
        var assetService = new AssetService(repo);
        var asset = new EntityAsset { Symbol = AssetSymbolConstants.SYMBOL_1, Type = AssetTypeConstants.TYPE_1 };
        assetService.AddAsset(portfolio.Id, asset);

        var service = new TransactionService(repo);
        var transaction = new EntityTransaction { Type = TransactionTypeConstants.TYPE_BUY, Price = 100, Quantity = 10, Date = DateTime.Now };

        //act
        service.AddTransaction(portfolio.Id, asset.Id, transaction);
        var result = repo.GetById(portfolio.Id);

        //assert
        Assert.NotNull(result);
        Assert.Single(result.Assets);
    }
}
