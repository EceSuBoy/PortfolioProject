using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioEce.ViewComponents
{
    public class _TestimonialComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
