using api.DTOs;
using api.Interfaces;
using api.Models;
using api.Repositories;

namespace api.Services
{
  public class ProductService : IProductService
  {
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
      return await _productRepository.GetAllAsync();
    }

    public async Task<Product?> GetByIdAsync(Guid id)
    {
      return await _productRepository.GetByIdAsync(id);
    }

    public async Task<Product> CreateAsync(ProductDTO newProductDTO)
    {
      if (await IsProductNameUnique(newProductDTO.Name))
      {
        var product = new Product();
        product.Name = "error_409_validations";
        return product;
      }

      var newProduct = new Product();
      newProduct.ProductID = Guid.NewGuid();
      newProduct.Name = newProductDTO.Name;
      newProduct.Price = newProductDTO.Price;
      newProduct.Quantity = newProductDTO.Quantity;
      newProduct.Discount = newProductDTO.Discount;
      newProduct.AnimalCategory = newProductDTO.AnimalCategory;
      newProduct.Image = newProductDTO.Image;
      newProduct.Description = newProductDTO.Description;
      newProduct.ProductType = newProductDTO.ProductType;
      newProduct.BrandID = newProductDTO.BrandID;
      newProduct.ProviderID = newProductDTO.ProviderID;

      if (newProductDTO.IsAvailable)
      {
        newProduct.IsAvailable = "true";
      }
      else
      {
        newProduct.IsAvailable = "false";
      }

      if (newProductDTO.HasTax)
      {
        newProduct.HasTax = "true";
      }
      else
      {
        newProduct.HasTax = "false";
      }

      await _productRepository.AddAsync(newProduct);

      return newProduct;
    }

    public async Task UpdateAsync(Guid id, ProductDTO productDTO)
    {
      var existingProduct = await GetByIdAsync(id);

      if (existingProduct is not null)
      {
        existingProduct.Name = productDTO.Name;
        existingProduct.Price = productDTO.Price;
        existingProduct.Quantity = productDTO.Quantity;
        existingProduct.Discount = productDTO.Discount;
        existingProduct.AnimalCategory = productDTO.AnimalCategory;
        existingProduct.Image = productDTO.Image;
        existingProduct.Description = productDTO.Description;
        existingProduct.BrandID = productDTO.BrandID;
        existingProduct.ProviderID = productDTO.ProviderID;

        if (productDTO.IsAvailable)
        {
          existingProduct.IsAvailable = "true";
        }
        else
        {
          existingProduct.IsAvailable = "false";
        }

        if (productDTO.HasTax)
        {
          existingProduct.HasTax = "true";
        }
        else
        {
          existingProduct.HasTax = "false";
        }

        await _productRepository.UpdateAsync(existingProduct);
      }
    }

    public async Task DeleteAsync(Guid id)
    {
      var productToDelete = await GetByIdAsync(id);

      if (productToDelete is not null)
      {
        await _productRepository.DeleteAsync(productToDelete.ProductID);
      }
    }

    public async Task<bool> IsProductNameUnique(string productName)
    {
      return await _productRepository.IsProductNameUnique(productName);
    }
  }
}
