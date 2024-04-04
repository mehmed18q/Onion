using Onion.Data.Account;

namespace Onion.Service.Interfaces
{
    public interface IUserService : IDisposable
    {
        User? GetUserById(int userId);
        Task Create(User user);
        void Update(User user);
        void Delete(User user);
    }
}
