using Microsoft.AspNetCore.Mvc;
using MyPortfolioEce.DAL.Context;

namespace MyPortfolioEce.ViewComponents
{
    public class _ContactComponentPartial: ViewComponent
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IViewComponentResult Invoke()
        {
            var values= context.Contacts.ToList();
            return View(values);
        }
    }
}
