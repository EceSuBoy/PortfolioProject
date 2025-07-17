using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioEce.ViewComponents
{
    public class _StatisticComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
