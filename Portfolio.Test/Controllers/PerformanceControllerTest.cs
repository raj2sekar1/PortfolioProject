using Portfolio.API.Controllers;
using Portfolio.Core.DTOs;
using Portfolio.Service;

namespace Portfolio.Test.Controllers;

public class PerformanceControllerTest
{
    [Fact]
    public void GetPerformance_ReturnsOk_WithExpectedResult()
    {
        //arrange
        var portfolioId = 1;
        var from = new DateTime(2024, 1, 1);
        var to = new DateTime(2024, 12, 31);
        var expectedDto = GetMockResult();
        var mockService = new Mock<IPerformanceService>();
        mockService
            .Setup(s => s.GetPerformance(portfolioId, from, to))
            .Returns(expectedDto);
        var controller = new PerformanceController(mockService.Object);

        //act
        var result = controller.GetPerformance(portfolioId, from, to);

        //assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var dto = Assert.IsType<PerformanceResultDto>(okResult.Value);
        Assert.Equal(expectedDto.TotalValue, dto.TotalValue);
        Assert.Equal(expectedDto.RealizedGain, dto.RealizedGain);
        Assert.Equal(expectedDto.UnrealizedGain, dto.UnrealizedGain);
    }

    [Fact]
    public void GetPerformance_WhenPortfolioNotFound_ThrowsException()
    {
        //arrange
        var mockService = new Mock<IPerformanceService>();
        mockService
            .Setup(s => s.GetPerformance(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
            .Throws(new Exception("Portfolio not found"));

        //act
        var controller = new PerformanceController(mockService.Object);

        //assert
        Assert.Throws<Exception>(() => controller.GetPerformance(It.IsAny<int>(), DateTime.Now, DateTime.Now));
    }

    private static PerformanceResultDto GetMockResult()
    {
        return new PerformanceResultDto
        {
            TotalValue = 10000m,
            Allocation = new Dictionary<string, decimal> { { "AAPL", 60 }, { "GOOG", 40 } },
            RealizedGain = 1200m,
            UnrealizedGain = 500m
        };
    }
}
