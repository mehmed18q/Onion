using Onion.Data.Account;
using Onion.Service.DTO.User;

namespace Onion.Service.Interfaces
{
	public interface IUserService : IDisposable
	{
		User? GetUserById(int userId);
		Task Create(User user);
		void Update(User user);
		void Delete(User user);
		void Delete(int userId);
		Task<bool> IsExistUserByEmail(string email);
		Task<bool> IsExistUserByEmail(string email, string currentEmail);
		Task<bool> IsExistUserByUserName(string userName);
		Task<bool> IsExistUserByUserName(string userName, string currenUserName);
		List<UserItemDto> GetUsers();
		User? GetUserByActiveCode(string activeCode);
		User? GetUserByUserName(string userName);
		AdminUsersDto GetUsersByFilter(AdminUsersDto filter);
		AdminEditUser? GetUserForEdit(int userId);
		Task<bool> HasUserThisPermission(string permissionName, string userName);
	}
}
