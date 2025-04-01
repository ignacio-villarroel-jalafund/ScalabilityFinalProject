using api.DTOs;
using api.Models;

namespace api.Interfaces
{
    public interface ICustomerService : IService<Customer, CustomerDTO>
    {
        Task<bool> IsCustomerNameUnique(string customerName);
        Task<bool> IsEmailUnique(string customerEmail);
    }
}