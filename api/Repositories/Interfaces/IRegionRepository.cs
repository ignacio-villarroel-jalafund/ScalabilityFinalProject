using api.Models;

namespace api.Repositories
{
    public interface IRegionRepository : IRepository<Region>
    {
        Task<bool> IsRegionNameUnique(string regionName);
    }
}
