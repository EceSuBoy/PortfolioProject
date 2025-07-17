using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioEce.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
