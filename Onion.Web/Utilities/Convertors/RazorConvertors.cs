using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Onion.Web.Utilities.Convertors
{
	public class RazorConvertors
	{
		public static string RenderPartialViewToString(string controllerName, string partialView, object model)
		{
			var context = new HttpContextWrapper(System.Web.HttpContext.Current) as HttpContextBase;

			var routes = new System.Web.Routing.RouteData();
			routes.Values.Add("controller", controllerName);

			RequestContext requestContext = new(context, routes);

			string requiredString = requestContext.RouteData.GetRequiredString("controller");
			var controllerFactory = ControllerBuilder.Current.GetControllerFactory();
			ControllerBase controller = controllerFactory.CreateController(requestContext, requiredString) as ControllerBase;

			controller.ControllerContext = new ControllerContext(context, routes, controller);
			ViewDataDictionary ViewData = new();

			TempDataDictionary TempData = new();

			ViewData.Model = model;

			using StringWriter sw = new();
			var viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, partialView);
			ViewContext viewContext = new(controller.ControllerContext, viewResult.View, ViewData, TempData, sw);

			viewResult.View.Render(viewContext, sw);
			return sw.GetStringBuilder().ToString();
		}
	}

}
