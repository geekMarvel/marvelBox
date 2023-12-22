using PetShop.Models.Entities;


namespace PetShop.Data.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryByNameAsync(string name);
        Task<Category> GetCategoryByIdAsync(int id);
        Task <IEnumerable<Category>> GetAllCategoriesAsync();
        //void AddComment(Comment comment);
        //void UpdateComment(Comment comment);
        //void DeleteComment(int id);
    }
}
