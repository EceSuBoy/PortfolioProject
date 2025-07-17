using Microsoft.AspNetCore.Mvc;
using MyPortfolioEce.DAL.Context;

namespace MyPortfolioEce.ViewComponents
{
    public class _ExperienceComponentPartial: ViewComponent
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values= context.Experiences.ToList();
            return View(values);
        }
    }
}
