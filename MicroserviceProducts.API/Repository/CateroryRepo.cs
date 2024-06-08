using MicroserviceProducts.API.Data;
using MicroserviceProducts.API.Models;

namespace MicroserviceProducts.API.Repository
{
    public class CateroryRepo : ICategoryRepo
    {
        private readonly ApplicationDbContext _dbcontext;

        public CateroryRepo(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _dbcontext.Categories.Find(categoryId);
            _dbcontext.Categories.Remove(category);
        }

        public IEnumerable<Category> GetCategory()
        {
            return _dbcontext.Categories.ToList();
        }

        public Category GetCategoryByID(int categoryId)
        {
            return _dbcontext.Categories.Find(categoryId);
        }

        public void InsertCategory(Category category)
        {
            _dbcontext.Add(category);
            Save();
        }

        public void UpdateCategory(Category category)
        {
            _dbcontext.Entry(Category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }
    }
}