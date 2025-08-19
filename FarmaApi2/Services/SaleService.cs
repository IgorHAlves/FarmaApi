using FarmaApi2.DTOs;
using FarmaApi2.Entity;
using FarmaApi2.Interfaces;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Dataflow;

namespace FarmaApi2.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IClientService _clientService;
        private readonly IProductService _productService;

        public SaleService(ISaleRepository saleRepository, IClientService clientService, IProductService productService)
        {
            _saleRepository = saleRepository;
            _clientService = clientService;
            _productService = productService;
        }

        public int CreateSale(CreateSaleDTO saleDTO) 
        {
            try
            {
                Client client = _clientService.GetClient(saleDTO.ClientId);

                Product product = _productService.GetProduct(saleDTO.ProductId);

                Sale sale = new Sale();

                sale.Product = product;
                sale.Client = client;
                sale.Date = DateTime.Now;

                int idSale = _saleRepository.CreateSale(sale);

                return idSale;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            } 
        }

        public Sale GetSale(int id)
        {
            throw new NotImplementedException();
        }

        public List<Sale> GetSales()
        {
            throw new NotImplementedException();
        }
    }
}
