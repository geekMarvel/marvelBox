using Microsoft.EntityFrameworkCore;
using PetShop.Data.Contexts;
using PetShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PetShop.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private PetShopDbContext _context;

        public UserRepository(PetShopDbContext context)
        {
            _context = context;
        }
        public async Task Create(User user)
        {
            user.Id = Guid.NewGuid();

            await _context.Users!.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        //public Task<User?> GetByEmailf(string email)
        //{
        //    return Task.FromResult(_context.Users!.FirstOrDefault(a => a.Email == email));
        //}
        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users!.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task<User?> GetByUsername(string username)
        {
            var user = await _context.Users!.FirstOrDefaultAsync(u => u.Username == username);
            //user?.Role.ToString();

            return user;
        }

    }
}
