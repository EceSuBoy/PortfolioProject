using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioEce.ViewComponents
{
    public class _HeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
