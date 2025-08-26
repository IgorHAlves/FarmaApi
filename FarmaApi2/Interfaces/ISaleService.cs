using FarmaApi2.DTOs;
using FarmaApi2.Entity;

namespace FarmaApi2.Interfaces
{
    public interface ISaleService
    {
        public Sale GetSale(Guid id);
        public List<Sale> GetSales();
        public Sale CreateSale(CreateSaleDTO sale);
    }
}
