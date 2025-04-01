using api.Data;
using api.Models;

namespace api.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(DataContext context) : base(context) { }
    }
}