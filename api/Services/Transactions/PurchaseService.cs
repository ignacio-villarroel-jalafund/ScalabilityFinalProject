using api.DTOs;
using api.Interfaces;
using api.Models;
using api.Repositories;

namespace api.Services
{
  public class PurchaseService : IPurchaseService
  {
    private readonly IPurchaseRepository _purchaseRepository;

    public PurchaseService(IPurchaseRepository purchaseRepository)
    {
      _purchaseRepository = purchaseRepository;
    }

    public async Task<IEnumerable<Purchase>> GetAllAsync()
    {
      return await _purchaseRepository.GetAllAsync();
    }

    public async Task<Purchase?> GetByIdAsync(Guid id)
    {
      return await _purchaseRepository.GetByIdAsync(id);
    }

    public async Task<Purchase> CreateAsync(PurchaseDTO newPurchaseDTO)
    {
      var newPurchase = new Purchase();
      newPurchase.PurchaseID = Guid.NewGuid();
      newPurchase.TotalPrice = newPurchaseDTO.TotalPrice;
      newPurchase.ObtainedTaxes = newPurchaseDTO.ObtainedTaxes;
      newPurchase.ReportDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); ;
      newPurchase.ApplicationTax = 7.5M;
      newPurchase.DeliveryTime = newPurchaseDTO.DeliveryTime;
      newPurchase.LocalQuantity = newPurchaseDTO.LocalQuantity;
      newPurchase.ProductID = newPurchaseDTO.ProductID;
      newPurchase.UserID = newPurchaseDTO.UserID;
      if (newPurchaseDTO.IsAvailable)
      {
        newPurchase.IsAvailable = "true";
      }
      else
      {
        newPurchase.IsAvailable = "false";
      }

      await _purchaseRepository.AddAsync(newPurchase);

      return newPurchase;
    }

    public async Task UpdateAsync(Guid id, PurchaseDTO purchaseDTO)
    {
      var existingPurchase = await GetByIdAsync(id);

      if (existingPurchase is not null)
      {
        existingPurchase.TotalPrice = purchaseDTO.TotalPrice;
        existingPurchase.ObtainedTaxes = purchaseDTO.ObtainedTaxes;
        existingPurchase.DeliveryTime = purchaseDTO.DeliveryTime;
        existingPurchase.LocalQuantity = purchaseDTO.LocalQuantity;
        existingPurchase.ProductID = purchaseDTO.ProductID;
        existingPurchase.UserID = purchaseDTO.UserID;
        if (purchaseDTO.IsAvailable)
        {
          existingPurchase.IsAvailable = "true";
        }
        else
        {
          existingPurchase.IsAvailable = "false";
        }

        await _purchaseRepository.UpdateAsync(existingPurchase);
      }
    }

    public async Task DeleteAsync(Guid id)
    {
      var purchaseToDelete = await GetByIdAsync(id);

      if (purchaseToDelete is not null)
      {
        await _purchaseRepository.DeleteAsync(purchaseToDelete.PurchaseID);
      }
    }
  }
}
