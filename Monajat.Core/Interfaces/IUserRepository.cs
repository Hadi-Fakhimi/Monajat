using Monajat.Core.Models;

namespace Monajat.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(User user);
        Task<bool> IsExistUserByUuid(Guid uuid);
        Task<User> GetUserByUuid(Guid uuid);
        void UserUpdate(User user);
        Task SaveChange();
    }
}
