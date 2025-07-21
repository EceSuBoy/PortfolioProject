using Microsoft.AspNetCore.Mvc;
using MyPortfolioEce.DAL.Context;

namespace MyPortfolioEce.ViewComponents
{
    public class _TestimonialComponentPartial: ViewComponent
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }
    }
}
