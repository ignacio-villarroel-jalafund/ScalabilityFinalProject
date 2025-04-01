using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository
    {
        public ProviderRepository(DataContext context) : base(context) { }

        public async Task<bool> IsProviderNameUnique(string providerName)
        {
            var providers = await _context.Providers.AsNoTracking().ToListAsync();
            return providers.Any(b => string.Equals(b.Name, providerName, StringComparison.OrdinalIgnoreCase));
        }
    }
}