using FarmaApi2.Data.DBContext;
using FarmaApi2.Entity;
using FarmaApi2.Interfaces;

namespace FarmaApi2.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly Context _context;

        public SaleRepository(Context context)
        {
            _context = context;
        }
        public Sale CreateSale(Sale saleNova)
        {
            _context.Sales.Add(saleNova);   
            _context.SaveChanges();

            return saleNova;
        }

        public Sale GetSale(Guid id)
        {
            Sale sale = _context.Sales.FirstOrDefault(sale => sale.Id == id);
            
            return sale;
        }

        public List<Sale> GetSales()
        {
            return _context.Sales.ToList();
        }
    }
}
