using MicroserviceProducts.API.Data;
using MicroserviceProducts.API.Models;

namespace MicroserviceProducts.API.Repository
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepo(ApplicationDbContext dbContex)
        {
            _dbContext = dbContex;
        }

        public void DeleteProduct(int productId)
        {
            var product = _dbContext.Products.Find(productId);
            _dbContext.Products.Remove(product);
            Save();
        }

        public Product GetProductByID(int productId)
        {
            return _dbContext.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _dbContext.Products.ToList();
        }

        public void InsertProduct(Product product)
        {
            _dbContext.Add(product);
            Save();
        }

        public void UpdateProduct(Product product)
        {
            _dbContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}