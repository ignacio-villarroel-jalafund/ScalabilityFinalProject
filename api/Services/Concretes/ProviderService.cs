using api.DTOs;
using api.Interfaces;
using api.Models;
using api.Repositories;

namespace api.Services
{
  public class ProviderService : IProviderService
  {
    private readonly IProviderRepository _providerRepository;

    public ProviderService(IProviderRepository providerRepository)
    {
      _providerRepository = providerRepository;
    }

    public async Task<IEnumerable<Provider>> GetAllAsync()
    {
      return await _providerRepository.GetAllAsync();
    }

    public async Task<Provider?> GetByIdAsync(Guid id)
    {
      return await _providerRepository.GetByIdAsync(id);
    }

    public async Task<Provider> CreateAsync(ProviderDTO newProviderDTO)
    {
      if (await IsProviderNameUnique(newProviderDTO.Name))
      {
        var provider = new Provider();
        provider.Name = "error_409_validations";
        return provider;
      }

      var newProvider = new Provider();
      newProvider.ProviderID = Guid.NewGuid();
      newProvider.Name = newProviderDTO.Name;
      newProvider.Nationality = newProviderDTO.Nationality;
      if (newProviderDTO.IsAvailable)
      {
        newProvider.IsAvailable = "true";
      }
      else
      {
        newProvider.IsAvailable = "false";
      }
      await _providerRepository.AddAsync(newProvider);

      return newProvider;
    }

    public async Task UpdateAsync(Guid id, ProviderDTO providerDTO)
    {
      var existingProvider = await GetByIdAsync(id);

      if (existingProvider is not null)
      {
        existingProvider.Name = providerDTO.Name;
        existingProvider.Nationality = providerDTO.Nationality;
        if (providerDTO.IsAvailable)
        {
          existingProvider.IsAvailable = "true";
        }
        else
        {
          existingProvider.IsAvailable = "false";
        }

        await _providerRepository.UpdateAsync(existingProvider);
      }
    }

    public async Task DeleteAsync(Guid id)
    {
      var providerToDelete = await GetByIdAsync(id);

      if (providerToDelete is not null)
      {
        await _providerRepository.DeleteAsync(providerToDelete.ProviderID);
      }
    }

    public async Task<bool> IsProviderNameUnique(string providerName)
    {
      return await _providerRepository.IsProviderNameUnique(providerName);
    }
  }
}
