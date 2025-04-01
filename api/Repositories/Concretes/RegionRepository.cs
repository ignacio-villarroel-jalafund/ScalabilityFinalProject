using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        public RegionRepository(DataContext context) : base(context) { }

        public async Task<bool> IsRegionNameUnique(string regionName)
        {
            var regions  = await _context.Regions.AsNoTracking().ToListAsync();
            return regions.Any(b => string.Equals(b.Name, regionName, StringComparison.OrdinalIgnoreCase));
        }
    }
}