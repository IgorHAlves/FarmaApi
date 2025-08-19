using FarmaApi2.DTOs;
using FarmaApi2.Entity;

namespace FarmaApi2.Interfaces
{
    public interface IProductService
    {
        public Product GetProduct(int id);
        public List<Product> GetProducts();
        public Product CreateProduct(CreateProductDTO dto);
    }
}
