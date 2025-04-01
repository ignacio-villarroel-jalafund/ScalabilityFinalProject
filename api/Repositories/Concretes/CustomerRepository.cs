using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context) { }

        public async Task<bool> IsCustomerNameUnique(string customerName)
        {
            var customers = await _context.Customers.AsNoTracking().ToListAsync();
            return customers.Any(b => string.Equals(b.Name, customerName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<bool> IsEmailUnique(string customerEmail)
        {
            var customers = await _context.Customers.AsNoTracking().ToListAsync();
            return customers.Any(b => string.Equals(b.Email, customerEmail, StringComparison.OrdinalIgnoreCase));
        }
    }
}