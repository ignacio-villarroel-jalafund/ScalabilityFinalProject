using api.Models;

namespace api.Repositories
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<bool> IsBrandNameUnique(string productName);
    }
}