using Microsoft.AspNetCore.Mvc;
using MyPortfolioEce.DAL.Context;

namespace MyPortfolioEce.ViewComponents
{
    public class _FooterComponentPartial: ViewComponent
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = context.SocialMedias.ToList();
            return View(values);
        }
    }
}
