using api.Data;
using api.Models;

namespace api.Repositories
{
    public class PurchaseRepository : Repository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(DataContext context) : base(context) { }
    }
}