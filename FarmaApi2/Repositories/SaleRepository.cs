using FarmaApi2.Entity;
using FarmaApi2.Interfaces;

namespace FarmaApi2.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ISaleRepository _saleRepository;
        public SaleRepository(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public Sale CreateSale(Sale saleNova)
        {
            Sale sale = _saleRepository.CreateSale(saleNova);   

            return sale;
        }

        public Sale GetSale(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSales()
        {
            throw new NotImplementedException();
        }
    }
}
