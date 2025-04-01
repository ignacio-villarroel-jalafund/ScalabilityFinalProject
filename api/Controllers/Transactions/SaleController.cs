using api.DTOs.Entities;
using api.Models.Transactions;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class SalesController : ControllerBase
  {
    private readonly SaleService _service;

    public SalesController(SaleService service)
    {
      _service = service;
    }

    [HttpGet(Name = "GetSales")]
    public async Task<IEnumerable<Sale>> Get()
    {
      return await _service.GetAllAsync();
    }

    [HttpGet("{id}", Name = "GetSale")]
    public async Task<ActionResult<Sale>> GetById(Guid id)
    {
      var sale = await _service.GetByIdAsync(id);

      return sale;
    }

    [HttpPost(Name = "AddSale")]
    public async Task<IActionResult> Create(SaleDTO saleDTO)
    {
      var newSale = await _service.CreateAsync(saleDTO);

      return CreatedAtAction(nameof(GetById), new { id = newSale.SaleID }, saleDTO);
    }

    [HttpPut("{id}", Name = "EditSale")]
    public async Task<IActionResult> Update(Guid id, SaleDTO saleDTO)
    {
      var saleToUpdate = await _service.GetByIdAsync(id);

      if (saleToUpdate is not null)
      {
        await _service.UpdateAsync(id, saleDTO);
        return NoContent();
      }
      else
      {
        return new NotFoundObjectResult(new { message = $"The {saleToUpdate} with ID = {id} doesn't exist." });
      }
    }
  }
}
