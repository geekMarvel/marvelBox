using Microsoft.EntityFrameworkCore;
using PetShop.Data.Contexts;
using PetShop.Models.Entities;


namespace PetShop.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {

        private PetShopDbContext _context;

        public CommentRepository(PetShopDbContext context)
        {
            _context = context;
        }
        public async Task<Comment> GetCommentByIdAsync(int id)
        {
            return await _context.Comments.FirstOrDefaultAsync(a => a.CommentId == id);
        }

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync()
        {

            return await _context.Comments.ToListAsync();
        }
        public async Task AddCommentAsync(Comment comment)
        {
            await _context.Comments!.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            var commentInDb = await GetCommentByIdAsync(comment.CommentId);
            commentInDb.Text = comment.Text;

            //_context.Comments.Update(comment);
            await _context.SaveChangesAsync();

        }
        public async Task DeleteCommentAsync(int id)
        {
            var comment = await GetCommentByIdAsync(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
