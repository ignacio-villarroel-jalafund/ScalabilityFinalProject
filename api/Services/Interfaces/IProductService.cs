using api.DTOs;
using api.Models;

namespace api.Interfaces
{
    public interface IProductService : IService<Product, ProductDTO>
    {
        Task<bool> IsProductNameUnique(string productName);
    }
}