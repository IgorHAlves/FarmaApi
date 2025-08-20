using FarmaApi2.Entity;

namespace FarmaApi2.Interfaces
{
    public interface ISaleRepository
    {
        public List<Sale> GetSales();
        public Sale GetSale(int id);
        public Sale CreateSale(Sale sale);
    }
}
