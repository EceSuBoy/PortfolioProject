using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioEce.ViewComponents.LayoutViewComponents
{
	public class _LayoutHeadComponentPartial: ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
