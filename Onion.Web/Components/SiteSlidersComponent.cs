using Microsoft.AspNetCore.Mvc;

namespace Onion.Components
{
	public class SiteSlidersComponent() : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("SiteSliders");
		}
	}
}
