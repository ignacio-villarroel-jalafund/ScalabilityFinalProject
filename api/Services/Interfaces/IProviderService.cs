using api.DTOs;
using api.Models;

namespace api.Interfaces
{
    public interface IProviderService : IService<Provider, ProviderDTO>
    {
        Task<bool> IsProviderNameUnique(string providerName);
    }
}