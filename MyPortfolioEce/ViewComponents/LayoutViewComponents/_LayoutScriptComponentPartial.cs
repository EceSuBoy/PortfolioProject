using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioEce.ViewComponents.LayoutViewComponents
{
	public class _LayoutScriptComponentPartial: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
