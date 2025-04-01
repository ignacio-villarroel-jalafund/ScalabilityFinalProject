using api.Models;

namespace api.Repositories
{
    public interface IProviderRepository : IRepository<Provider>
    {
        Task<bool> IsProviderNameUnique(string productName);
    }
}