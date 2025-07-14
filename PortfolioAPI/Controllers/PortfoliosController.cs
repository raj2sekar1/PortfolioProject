using Portfolio.Service;

namespace Portfolio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PortfoliosController(
    IPortfolioService service) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(service.GetAll());
    }

    [HttpPost]
    public IActionResult Create([FromBody] string name)
    {
        return Ok(service.Create(name));
    }
}
