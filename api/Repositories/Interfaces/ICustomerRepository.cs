using api.Models;

namespace api.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<bool> IsCustomerNameUnique(string customerName);
        Task<bool> IsEmailUnique(string customerEmail);
    }
}