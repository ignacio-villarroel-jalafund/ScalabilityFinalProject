using api.DTOs.Entities;
using api.Interfaces;
using api.Models.Transactions;
using api.Repositories;

namespace api.Services
{
  public class SaleService : ISaleService
  {
    private readonly ISaleRepository _saleRepository;

    public SaleService(ISaleRepository saleRepository)
    {
      _saleRepository = saleRepository;
    }

    public async Task<IEnumerable<Sale>> GetAllAsync()
    {
      return await _saleRepository.GetAllAsync();
    }

    public async Task<Sale?> GetByIdAsync(Guid id)
    {
      return await _saleRepository.GetByIdAsync(id);
    }

    public async Task<Sale> CreateAsync(SaleDTO newSaleDTO)
    {
      var newSale = new Sale();
      newSale.SaleID = Guid.NewGuid();
      newSale.ZipCode = newSaleDTO.ZipCode;
      newSale.Cvv = newSaleDTO.Cvv;
      newSale.CardNumber = newSaleDTO.CardNumber;
      newSale.Date = newSaleDTO.Date;
      newSale.FinalPrice = newSaleDTO.FinalPrice;
      newSale.UserID = newSaleDTO.UserID;
      newSale.IsAvailable = newSaleDTO.IsAvailable;

      await _saleRepository.AddAsync(newSale);

      return newSale;
    }

    public async Task UpdateAsync(Guid id, SaleDTO saleDTO)
    {
      var existingSale = await GetByIdAsync(id);

      if (existingSale is not null)
      {
        existingSale.ZipCode = saleDTO.ZipCode;
        existingSale.Cvv = saleDTO.Cvv;
        existingSale.CardNumber = saleDTO.CardNumber;
        existingSale.Date = saleDTO.Date;
        existingSale.FinalPrice = saleDTO.FinalPrice;
        existingSale.UserID = saleDTO.UserID;
        existingSale.IsAvailable = saleDTO.IsAvailable;

        await _saleRepository.UpdateAsync(existingSale);
      }
    }

    public async Task DeleteAsync(Guid id)
    {
      var saleToDelete = await GetByIdAsync(id);

      if (saleToDelete is not null)
      {
        await _saleRepository.DeleteAsync(saleToDelete.SaleID);
      }
    }
  }
}
