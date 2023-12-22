using Microsoft.EntityFrameworkCore;
using PetShop.Data.Contexts;
using PetShop.Models.Entities;


namespace PetShop.Data.Repositories
{
    public class CategoryRepository: ICategoryRepository
    {
        private PetShopDbContext _context;

        public CategoryRepository(PetShopDbContext context)
        {
            _context = context;
        }

        public async Task<Category> GetCategoryByNameAsync(string name)
        {
            return await _context.Categories!.SingleAsync(a => a.Name == name);
        }      
        public  Task<Category> GetCategoryByIdAsync(int id)
        {
            return Task.FromResult(_context.Categories!.Single(a => a.CategoryId == id));
        }
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync()!;
        }
    }
}
