using api.DTOs;
using api.Models;

namespace api.Interfaces
{
    public interface IBrandService : IService<Brand, BrandDTO>
    {
        Task<bool> IsBrandNameUnique(string brandName);
    }
}