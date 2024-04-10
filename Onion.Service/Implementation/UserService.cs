using Onion.Data.Access;
using Onion.Data.Account;
using Onion.Repository.DataTransfer;
using Onion.Service.DTO.Paging;
using Onion.Service.DTO.User;
using Onion.Service.Extensions;
using Onion.Service.Interfaces;

namespace Onion.Service.Implementation
{
	public class UserService(IBaseRepository<User> userRepository, IBaseRepository<UserRole> userRoleRepository) : IUserService
	{
		private readonly IBaseRepository<User> _userRepository = userRepository;
		private readonly IBaseRepository<UserRole> _userRoleRepository = userRoleRepository;
		public void Dispose()
		{
			_userRepository?.Dispose();
			_userRoleRepository?.Dispose();
		}

		public async Task Create(User user)
		{
			await _userRepository.Insert(user);
			await _userRepository.Save();
		}

		public User? GetUserById(int userId)
		{
			return _userRepository.GetById(userId);
		}

		public void Update(User user)
		{
			_userRepository.Update(user);
		}

		public void Delete(User user)
		{
			_userRepository.Delete(user);
		}

		public async Task<bool> IsExistUserByUserName(string userName)
		{
			return await _userRepository.IsExist(u => u.UserName == userName);
		}

		public async Task<bool> IsExistUserByEmail(string email)
		{
			return await _userRepository.IsExist(u => u.Email == email);
		}

		public void Delete(int userId)
		{
			User? user = GetUserById(userId);
			if (user is not null)
			{
				_userRepository.Delete(user);
			}
		}

		public List<UserItemDto> GetUsers()
		{
			return _userRepository.Get().Select(u => new UserItemDto
			{
				Email = u.Email,
				UserName = u.UserName,
			}).ToList();
		}

		public Task<bool> IsExistUserByEmail(string email, string currentEmail)
		{
			return _userRepository.IsExist(s => s.Email == email && s.Email != currentEmail);
		}

		public Task<bool> IsExistUserByUserName(string userName, string currenUserName)
		{
			return _userRepository.IsExist(s => s.UserName == userName && s.UserName != currenUserName);
		}

		public User? GetUserByActiveCode(string activeCode)
		{
			return _userRepository.Get(s => s.ActiveCode == activeCode).FirstOrDefault();
		}

		public User? GetUserByUserName(string userName)
		{
			return _userRepository.Get(s => s.UserName == userName).SingleOrDefault();
		}

		public AdminUsersDto GetUsersByFilter(AdminUsersDto filter)
		{
			IQueryable<User> query = _userRepository.Get(null).AsQueryable().SetUsersFilter(filter);

			int count = (int)Math.Ceiling(query.Count() / (double)filter.TakeEntity);

			BasePaging pager = Pager.Build(count, filter.PageId, filter.TakeEntity);

			List<User> users = [.. query.OrderByDescending(s => s.Id).Paging(pager)];

			return filter.SetUsers(users).SetPagingItems(pager);

		}

		public AdminEditUser? GetUserForEdit(int userId)
		{
			User? user = GetUserByUserId(userId);

			return user is null
				? null
				: new AdminEditUser
				{
					Email = user.Email,
					UserId = user.Id,
					CurrentEmail = user.Email,
					UserName = user.UserName,
					CurrentUserName = user.UserName,
					IsActive = user.IsActive
				};
		}

		public async Task<bool> HasUserThisPermission(string permissionName, string userName)
		{
			return await _userRoleRepository.Any(s => s.Role.Name == permissionName && s.User.UserName == userName);
		}

		public User? GetUserByUserId(int userId)
		{
			return _userRepository.GetById(userId);
		}
	}
}
