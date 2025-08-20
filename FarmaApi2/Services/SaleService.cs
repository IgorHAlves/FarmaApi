using FarmaApi2.DTOs;
using FarmaApi2.Entity;
using FarmaApi2.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public Sale GetSale(int id)
        {
            try
            {
                Sale sale = _saleRepository.GetSale(id);

                return sale;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao localizar venda: " + ex.Message);
            }
        }

        public List<Sale> GetSales()
        {
            try
            {
                List<Sale> sales = _saleRepository.GetSales();

                return sales;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao localizar vendas: " + ex.Message);

            }
        }

        public Sale CreateSale(CreateSaleDTO saleDTO) 
        {
            try
            {
                Client client = _clientService.GetClient(saleDTO.ClientId) ?? throw new KeyNotFoundException("Cliente não encontrado");

                Product product = _productService.GetProduct(saleDTO.ProductId) ?? throw new KeyNotFoundException("Produto não encontrado");

                Sale sale = new Sale();

                sale.Product = product;
                sale.Client = client;
                sale.Date = DateTime.Now;

                Sale newSale = _saleRepository.CreateSale(sale);

                return newSale;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar venda: " + ex.Message);
            } 
        }



    }
}
