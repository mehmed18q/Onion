using Microsoft.AspNetCore.Mvc;

namespace Onion.Components
{
	public class FooterSliderComponent() : ViewComponent
	{
		public async Task<IViewComponentResult> InvokeAsync()
		{
			return View("FooterSlider");
		}
	}
}
