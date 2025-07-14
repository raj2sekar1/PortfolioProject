using Portfolio.API.Controllers;
using Portfolio.DB.Entities;
using Portfolio.Service;

namespace Portfolio.Test.Controllers;

public class PortfoliosControllerTest
{
    [Fact]
    public void When_PortfoliosControllerApi_Called_ReturnResponse()
    {
        //arrange
        var mockService = new Mock<IPortfolioService>();
        mockService.Setup(s => s.GetAll()).Returns(GetMockPortfolios());
        var controller = new PortfoliosController(mockService.Object);

        //act
        var result = controller.Get();

        //assert
        var ok = Assert.IsType<OkObjectResult>(result);
        var list = Assert.IsType<IEnumerable<EntityPortfolio>>(ok.Value, exactMatch: false);
        Assert.NotEmpty(list);
    }

    private List<EntityPortfolio> GetMockPortfolios()
    {
        return
        [
            new() { Id = 1, Name = "Test1" },
            new() { Id = 2, Name = "Test2" }
        ];
    }
}
