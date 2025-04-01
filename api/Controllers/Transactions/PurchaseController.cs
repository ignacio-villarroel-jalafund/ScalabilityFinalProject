using api.DTOs;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PurchaseController : ControllerBase
  {
    private readonly PurchaseService _service;

    public PurchaseController(PurchaseService service)
    {
      _service = service;
    }

    [HttpGet(Name = "GetPurchases")]
    public async Task<IEnumerable<Purchase>> Get()
    {
      return await _service.GetAllAsync();
    }

    [HttpGet("{id}", Name = "GetPurchase")]
    public async Task<ActionResult<Purchase>> GetById(Guid id)
    {
      var purchase = await _service.GetByIdAsync(id);

      return purchase;
    }

    [HttpPost(Name = "AddPurchase")]
    public async Task<IActionResult> Create(PurchaseDTO purchaseDTO)
    {
      var newPurchase = await _service.CreateAsync(purchaseDTO);

      return CreatedAtAction(nameof(GetById), new { id = newPurchase.PurchaseID }, purchaseDTO);
    }

    [HttpPut("{id}", Name = "EditPurchase")]
    public async Task<IActionResult> Update(Guid id, PurchaseDTO purchaseDTO)
    {
      var purchaseToUpdate = await _service.GetByIdAsync(id);

      if (purchaseToUpdate is not null)
      {
        await _service.UpdateAsync(id, purchaseDTO);
        return NoContent();
      }
      else
      {
        return new NotFoundObjectResult(new { message = $"The {purchaseToUpdate} with ID = {id} doesn't exist." });
      }
    }
  }
}
