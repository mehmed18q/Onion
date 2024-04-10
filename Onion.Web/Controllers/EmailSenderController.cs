using Microsoft.AspNetCore.Mvc;

namespace Onion.Web.Controllers
{
	public class EmailSenderController : Controller
	{
		public ActionResult ActivateEmail()
		{
			return PartialView();
		}
	}
}
