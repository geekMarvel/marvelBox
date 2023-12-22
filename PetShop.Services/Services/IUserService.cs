using PetShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services.Services
{
    public interface IUserService
    {
        Task<User?> GetByEmail(string email);

        Task<User?> GetByUsername(string username);

        Task Create(User user);
    }
}
