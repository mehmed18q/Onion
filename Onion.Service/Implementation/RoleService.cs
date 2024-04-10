using Onion.Data.Access;
using Onion.Repository.DataTransfer;
using Onion.Service.Interfaces;

namespace Onion.Service.Implementation
{
	public class RoleService(IBaseRepository<Role> userRoleRepository) : IRoleService
	{
		private readonly IBaseRepository<Role> _roleRepository = userRoleRepository;

		public void Dispose() => _roleRepository?.Dispose();
	}
}
