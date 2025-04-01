using api.DTOs;
using api.Interfaces;
using api.Models;
using api.Repositories;

namespace api.Services
{
  public class RegionService : IRegionService
  {
    private readonly IRegionRepository _regionRepository;

    public RegionService(IRegionRepository regionRepository)
    {
      _regionRepository = regionRepository;
    }

    public async Task<IEnumerable<Region>> GetAllAsync()
    {
      return await _regionRepository.GetAllAsync();
    }

    public async Task<Region?> GetByIdAsync(Guid id)
    {
      return await _regionRepository.GetByIdAsync(id);
    }

    public async Task<Region> CreateAsync(RegionDTO newRegionDTO)
    {
      var newRegion = new Region();
      newRegion.RegionID = Guid.NewGuid();
      newRegion.Name = newRegionDTO.Name;
      newRegion.MunicipalTax = newRegionDTO.MunicipalTax;
      newRegion.StatalTax = newRegionDTO.StatalTax;

      await _regionRepository.AddAsync(newRegion);

      return newRegion;
    }

    public async Task UpdateAsync(Guid id, RegionDTO regionDTO)
    {
      var existingRegion = await GetByIdAsync(id);

      if (existingRegion is not null)
      {
        existingRegion.Name = regionDTO.Name;
        existingRegion.MunicipalTax = regionDTO.MunicipalTax;
        existingRegion.StatalTax = regionDTO.StatalTax;

        await _regionRepository.UpdateAsync(existingRegion);
      }
    }

    public async Task DeleteAsync(Guid id)
    {
      var regionToDelete = await GetByIdAsync(id);

      if (regionToDelete is not null)
      {
        await _regionRepository.DeleteAsync(regionToDelete.RegionID);
      }
    }
  }
}
