using Onion.Data.Account;
using Onion.Repository.DataTransfer;
using Onion.Service.Interfaces;

namespace Onion.Service.Implementation
{
    public class UserService(IRepository<User> repository) : IUserService
    {
        private IRepository<User> _repository = repository;

        public async Task Create(User user)
        {
            await _repository.Insert(user);
            await _repository.Save();
        }
        public User? GetUserById(int userId)
        {
            return _repository.GetById(userId);
        }

        public void Update(User user)
        {
            _repository.Update(user);
        }

        public void Delete(User user)
        {
            _repository.Delete(user);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
