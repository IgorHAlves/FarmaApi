using FarmaApi2.DTOs;
using FarmaApi2.Entity;

namespace FarmaApi2.Interfaces
{
    public interface IProductRepository
    {
        public Product GetProduct(Guid id);
        public List<Product> GetProducts();
        public Product CreateProduct(Product product);
    }
}