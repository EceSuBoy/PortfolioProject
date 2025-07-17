using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioEce.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
