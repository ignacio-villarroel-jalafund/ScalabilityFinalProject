using api.DTOs;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class RegionController : ControllerBase
  {
    private readonly RegionService _service;

    public RegionController(RegionService service)
    {
      _service = service;
    }

    [HttpGet(Name = "GetRegions")]
    public async Task<IEnumerable<Region>> Get()
    {
      return await _service.GetAllAsync();
    }

    [HttpGet("{id}", Name = "GetRegion")]
    public async Task<ActionResult<Region>> GetById(Guid id)
    {
      var region = await _service.GetByIdAsync(id);

      return region;
    }

    [HttpPost(Name = "AddRegion")]
    [Authorize]
    public async Task<IActionResult> Create(RegionDTO regionDTO)
    {
      var newRegion = await _service.CreateAsync(regionDTO);

      return CreatedAtAction(nameof(GetById), new { id = newRegion.RegionID }, regionDTO);
    }

    [HttpPut("{id}", Name = "EditRegion")]
    [Authorize]
    public async Task<IActionResult> Update(Guid id, RegionDTO regionDTO)
    {
      var regionToUpdate = await _service.GetByIdAsync(id);

      if (regionToUpdate is not null)
      {
        await _service.UpdateAsync(id, regionDTO);
        return NoContent();
      }
      else
      {
        return new NotFoundObjectResult(new { message = $"The {regionToUpdate} with ID = {id} doesn't exist." });
      }
    }
  }
}
