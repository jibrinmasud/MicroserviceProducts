using MicroserviceProducts.API.Models;

namespace MicroserviceProducts.API.Repository
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetProducts();

        public void DeleteProduct(int productId);

        public Product GetProductByID(int productId);

        public void InsertProduct(Product product);

        public void UpdateProduct(Product product);
    }
}