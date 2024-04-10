using Microsoft.AspNetCore.Mvc;
using Onion.Web.UOW;

namespace Onion.Web.Controllers
{
	public class ValidateController(IUnitOfWork unitOfWork) : Controller
	{
		private readonly IUnitOfWork _unitOfWork = unitOfWork;
		public async Task<IActionResult> IsExistUserByEmail(string Email)
		{
			return Json(await _unitOfWork.UserService.IsExistUserByEmail(Email));
		}
	}
}
