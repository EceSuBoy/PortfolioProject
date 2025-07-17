using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioEce.ViewComponents
{
    public class _NavbarComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
