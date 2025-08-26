using FarmaApi2.Data.DBContext;
using FarmaApi2.Entity;
using FarmaApi2.Interfaces;

namespace FarmaApi2.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }
        public Product CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            return _context.Products.FirstOrDefault(product => product.Id.Equals(id));
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}
