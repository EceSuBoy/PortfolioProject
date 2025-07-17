using Microsoft.AspNetCore.Mvc;
using MyPortfolioEce.DAL.Context;

namespace MyPortfolioEce.ViewComponents
{
    public class _FeatureComponentPartial : ViewComponent
    {
        MyPortfolioContext portfolioContext= new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values = portfolioContext.Features.ToList();
            return View(values);
        }
    }
}
