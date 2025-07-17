using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace MyPortfolioEce.ViewComponents
{
    public class _PortfolioComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
