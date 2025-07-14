using Portfolio.DB.Entities;
using Portfolio.DB.Repositories;
using Portfolio.Service.Concretes;
using static Portfolio.Core.Constants;
using Xunit;

namespace Portfolio.Test.Services;

public class AssetServiceTest
{
    [Fact]
    public void When_AddAsset_Called_Return_Success()
    {
        //arrange
        var repo = new InMemoryPortfolioRepository();
        var portfolioService = new PortfolioService(repo);
        var portfolio = portfolioService.Create("Test Portfolio");
        var assetService = new AssetService(repo);
        var asset = new EntityAsset { Symbol = AssetSymbolConstants.SYMBOL_1, Type = AssetTypeConstants.TYPE_1 };

        //act
        assetService.AddAsset(portfolio.Id, asset);
        var result = repo.GetById(portfolio.Id);

        //assert
        Assert.NotNull(result);
        Assert.Single(result.Assets);
    }
}
