using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<Product>> GetProductsByBrandAsync(Guid brandId)
        {
            return await _context.Products.Where(p => p.BrandID == brandId).ToListAsync();
        }

        public async Task<bool> IsProductNameUnique(string productName)
        {
            var products = await _context.Products.AsNoTracking().ToListAsync();
            return products.Any(b => string.Equals(b.Name, productName, StringComparison.OrdinalIgnoreCase));
        }
    }
}