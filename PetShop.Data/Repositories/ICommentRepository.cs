using Microsoft.EntityFrameworkCore;
using PetShop.Models.Entities;


namespace PetShop.Data.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment> GetCommentByIdAsync(int id);
        //IEnumerable<Comment> GetAllComments();
        Task<IEnumerable<Comment>> GetAllCommentsAsync();
        Task AddCommentAsync(Comment comment);
        Task UpdateCommentAsync(Comment comment);
        Task DeleteCommentAsync(int id);
    }
}
