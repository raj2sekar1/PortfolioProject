using Portfolio.Core.DTOs;
using Portfolio.DB.Entities;
using Portfolio.Service;

namespace Portfolio.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionsController(
    ITransactionService service) : ControllerBase
{
    [HttpPost("{id}/assets/{assetId}/transactions")]
    public IActionResult AddTransaction(int id, int assetId, [FromBody] TransactionDto dto)
    {
        var tx = new EntityTransaction { Date = dto.Date, Type = dto.Type, Quantity = dto.Quantity, Price = dto.Price };
        service.AddTransaction(id, assetId, tx);

        return Ok();
    }
}
