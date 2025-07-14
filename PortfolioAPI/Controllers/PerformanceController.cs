using Portfolio.Service;

namespace Portfolio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PerformanceController(
    IPerformanceService service) : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetPerformance(int id, [FromQuery] DateTime from, [FromQuery] DateTime to)
    {
        var result = service.GetPerformance(id, from, to);

        return Ok(result);
    }
}
