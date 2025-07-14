using Portfolio.DB.Repositories;
using Portfolio.Service.Concretes;

namespace Portfolio.Test.Services;

public class PortfolioServiceTests
{
    [Fact]
    public void When_CreatePortfolio_Called_Return_Success()
    {
        //arrange
        var repo = new InMemoryPortfolioRepository();
        var service = new PortfolioService(repo);

        //act
        var portfolio = service.Create("Test Portfolio");

        //assert
        Assert.NotNull(portfolio);
        Assert.Equal("Test Portfolio", portfolio.Name);
        Assert.Single(repo.GetAll());
    }
}
