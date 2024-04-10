using Microsoft.AspNetCore.Authorization;
using Onion.Web.UOW;

namespace Onion.Web.Utilities.Security
{
	public class PermissionChecker : AuthorizeAttribute
	{
		private string roleName;

		public PermissionChecker(string roleName)
		{
			this.roleName = roleName;
		}

		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			if (!UserManager.IsUserAuthenticated())
			{
				return false;
			}

			UnitOfWork unitOfWork = new(new OnionContext());

			return unitOfWork.UserService.HasUserThisPermission(roleName, UserManager.GetCurrentUserName());
		}
	}

}
