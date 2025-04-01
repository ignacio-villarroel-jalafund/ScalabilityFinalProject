using api.DTOs;
using api.Interfaces;
using api.Models;
using api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api.Services
{
  public class BrandService : IBrandService
  {
    private readonly IBrandRepository _brandRepository;

    public BrandService(IBrandRepository brandRepository)
    {
      _brandRepository = brandRepository;
    }

    public async Task<IEnumerable<Brand>> GetAllAsync()
    {
      return await _brandRepository.GetAllAsync();
    }

    public async Task<Brand?> GetByIdAsync(Guid id)
    {
      return await _brandRepository.GetByIdAsync(id);
    }

    public async Task<Brand> CreateAsync([FromBody] BrandDTO newBrandDTO)
    {
      if (await IsBrandNameUnique(newBrandDTO.Name))
      {
        var brand = new Brand();
        brand.Name = "error_409_validations";
        return brand;
      }

      var newBrand = new Brand();
      newBrand.BrandID = Guid.NewGuid();
      newBrand.Name = newBrandDTO.Name;
      newBrand.Logo = newBrandDTO.Logo;
      if (newBrandDTO.IsAvailable)
      {
        newBrand.IsAvailable = "true";
      }
      else
      {
        newBrand.IsAvailable = "false";
      }

      await _brandRepository.AddAsync(newBrand);

      return newBrand;
    }

    public async Task UpdateAsync(Guid id, [FromBody] BrandDTO brandDTO)
    {
      var existingBrand = await GetByIdAsync(id);

      if (existingBrand is not null)
      {
        existingBrand.Name = brandDTO.Name;
        existingBrand.Logo = brandDTO.Logo;
        if (brandDTO.IsAvailable)
        {
          existingBrand.IsAvailable = "true";
        }
        else
        {
          existingBrand.IsAvailable = "false";
        }

        await _brandRepository.UpdateAsync(existingBrand);
      }
    }

    public async Task DeleteAsync(Guid id)
    {
      var brandToDelete = await GetByIdAsync(id);

      if (brandToDelete is not null)
      {
        await _brandRepository.DeleteAsync(brandToDelete.BrandID);
      }
    }

    public async Task<bool> IsBrandNameUnique(string brandName)
    {
      return await _brandRepository.IsBrandNameUnique(brandName);
    }
  }
}
