using api.DTOs;
using api.Interfaces;
using api.Models;
using api.Repositories;

namespace api.Services
{
  public class ReviewService : IReviewService
  {
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IReviewRepository reviewRepository)
    {
      _reviewRepository = reviewRepository;
    }

    public async Task<IEnumerable<Review>> GetAllAsync()
    {
      return await _reviewRepository.GetAllAsync();
    }

    public async Task<Review?> GetByIdAsync(Guid id)
    {
      return await _reviewRepository.GetByIdAsync(id);
    }

    public async Task<Review> CreateAsync(ReviewDTO newReviewDTO)
    {
      var newReview = new Review();
      newReview.ReviewID = Guid.NewGuid();
      newReview.CustomerID = newReviewDTO.CustomerID;
      newReview.ProductID = newReviewDTO.ProductID;
      newReview.ReviewMessage = newReviewDTO.ReviewMessage;

      await _reviewRepository.AddAsync(newReview);

      return newReview;
    }

    public async Task UpdateAsync(Guid id, ReviewDTO reviewDTO)
    {
      var existingReview = await GetByIdAsync(id);

      if (existingReview is not null)
      {
        existingReview.CustomerID = reviewDTO.CustomerID;
        existingReview.ProductID = reviewDTO.ProductID;
        existingReview.ReviewMessage = reviewDTO.ReviewMessage;

        await _reviewRepository.UpdateAsync(existingReview);
      }
    }

    public async Task DeleteAsync(Guid id)
    {
      var reviewToDelete = await GetByIdAsync(id);

      if (reviewToDelete is not null)
      {
        await _reviewRepository.DeleteAsync(reviewToDelete.ReviewID);
      }
    }
  }
}
