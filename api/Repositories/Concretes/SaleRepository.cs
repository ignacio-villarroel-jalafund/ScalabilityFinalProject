using api.Data;
using api.Models.Transactions;

namespace api.Repositories
{
    public class SaleRepository : Repository<Sale>, ISaleRepository
    {
        public SaleRepository(DataContext context) : base(context) { }
    }
}