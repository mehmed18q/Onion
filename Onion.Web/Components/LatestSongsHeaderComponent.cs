using Microsoft.AspNetCore.Mvc;

namespace Onion.Components
{
	public class LatestSongsHeaderComponent() : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("LatestSongsHeader");
		}
	}
}
