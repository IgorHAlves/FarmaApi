using FarmaApi2.DTOs;
using FarmaApi2.Entity;
using FarmaApi2.Interfaces;

namespace FarmaApi2.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository; 
        }

        public Product GetProduct(int id)
        {
            try
            {
                Product product = _productRepository.GetProduct(id);

                return product;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao localizar produto: " + ex.Message);
            }
        }

        public List<Product> GetProducts()
        {
            try
            {
                List<Product> products = _productRepository.GetProducts();

                return products;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao localizar produtos: " + ex.Message);

            }

        }

        public Product CreateProduct(CreateProductDTO dto)
        {
            try
            {
                Product product = new Product();

                product.Name = dto.Name;
                product.Price = dto.Price;
                product.Brand = dto.Brand;

                Product newProduct = _productRepository.CreateProduct(product);

                return newProduct;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar produtos: " + ex.Message);

            }

        }


    }
}
