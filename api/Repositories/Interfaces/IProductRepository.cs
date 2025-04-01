using api.Models;

namespace api.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsByBrandAsync(Guid brandId);
        Task<bool> IsProductNameUnique(string productName);
    }
}