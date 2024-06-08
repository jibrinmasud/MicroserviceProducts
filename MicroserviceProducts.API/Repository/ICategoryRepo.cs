using MicroserviceProducts.API.Models;

namespace MicroserviceProducts.API.Repository
{
    public interface ICategoryRepo
    {
        public IEnumerable<Category> GetCategory();

        public void DeleteCategory(int categoryId);

        public Category GetCategoryByID(int categoryId);

        public void InsertCategory(Category category);

        public void UpdateCategory(Category category);
    }
}