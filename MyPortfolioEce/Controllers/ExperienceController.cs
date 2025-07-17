using Microsoft.AspNetCore.Mvc;

namespace MyPortfolioEce.Controllers
{
    public class ExperienceController : Controller
    {
        public IActionResult ExperienceList()
        {
            return View();
        }
    }
}
