using Microsoft.AspNetCore.Mvc;

namespace Onion.Components
{
	public class FavoritesComponent() : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("Favorites");
		}
	}
}
