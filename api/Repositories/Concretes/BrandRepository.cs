using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(DataContext context) : base(context) { }

        public async Task<bool> IsBrandNameUnique(string brandName)
        {
            var brands = await _context.Brands.AsNoTracking().ToListAsync();
            return brands.Any(b => string.Equals(b.Name, brandName, StringComparison.OrdinalIgnoreCase));
        }
    }
}