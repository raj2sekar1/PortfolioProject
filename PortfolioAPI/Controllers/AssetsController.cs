using Portfolio.Core.DTOs;
using Portfolio.DB.Entities;
using Portfolio.Service;

namespace Portfolio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssetsController(
    IAssetService service) : ControllerBase
{
    [HttpPost("{id}/assets")]
    public IActionResult AddAsset(int id, [FromBody] AssetDto dto)
    {
        var asset = new EntityAsset { Symbol = dto.Symbol, Type = dto.Type };
        service.AddAsset(id, asset);

        return Ok();
    }
}
