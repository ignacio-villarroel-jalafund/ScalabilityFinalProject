using api.DTOs;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _service;

        public ReviewController(ReviewService service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetReviews")]
    public async Task<IEnumerable<Review>> Get()
    {
        return await _service.GetAllAsync();
    }

    [HttpGet("{id}", Name = "GetReview")]
    public async Task<ActionResult<Review>> GetById(Guid id)
    {
        var review = await _service.GetByIdAsync(id);

        return review;
    }

    [HttpPost(Name = "AddReview")]
    public async Task<IActionResult> Create(ReviewDTO reviewDTO)
    {
        var newReview = await _service.CreateAsync(reviewDTO);

        return CreatedAtAction(nameof(GetById), new { id = newReview.ReviewID }, reviewDTO);
    }

    [HttpPut("{id}", Name = "EditReview")]
    public async Task<IActionResult> Update(Guid id, ReviewDTO reviewDTO)
    {
      var reviewToUpdate = await _service.GetByIdAsync(id);

      if (reviewToUpdate is not null)
      {
        await _service.UpdateAsync(id, reviewDTO);
        return NoContent();
      }
      else
      {
        return new NotFoundObjectResult(new { message = $"The {reviewToUpdate} with ID = {id} doesn't exist." });
      }
    }

    [HttpDelete(Name = "DeleteReview")]
    public async Task<IActionResult> Delete(Guid id)
    {
      var existingReview = await _service.GetByIdAsync(id);

      if (existingReview is not null)
      {
        await _service.DeleteAsync(id);
        return Ok();
      } else {
        return new NotFoundObjectResult(new { message = $"The {existingReview} with ID = {id} doesn't exist." });
      }
    }
  }
}
