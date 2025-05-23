using Microsoft.EntityFrameworkCore;
using Monajat.Core.Interfaces;
using Monajat.Core.Models;
using Monajat.Infra.Data.Context;

namespace Monajat.Infra.Data.Repositories
{
    public class UserRepository:IUserRepository 
    {
        #region Construuctor

        private readonly MonajatDbContext _context;

        public UserRepository(MonajatDbContext context)
        {
            _context = context;
        }

        #endregion
        public async Task<bool> CreateUser(User user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await SaveChange();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<bool> IsExistUserByUuid(Guid uuid)
        {
            return await _context.Users.AsQueryable().AnyAsync(u => u.Uuid.Equals(uuid));
        }

        public async Task<User> GetUserByUuid(Guid uuid)
        {
            return await _context.Users.AsQueryable().FirstOrDefaultAsync(u => u.Uuid.Equals(uuid));
        }

        public  void UserUpdate(User user)
        {
             _context.Users.Update(user);
        }

        public async Task SaveChange()
        {
            await _context.SaveChangesAsync();
        }
    }
}
