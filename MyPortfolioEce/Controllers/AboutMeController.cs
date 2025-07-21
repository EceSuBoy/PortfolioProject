using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioEce.DAL.Context;
using MyPortfolioEce.DAL.Entities;
using System.Data;

namespace MyPortfolioEce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutMeController : Controller
    {
        MyPortfolioContext context= new MyPortfolioContext();
        public IActionResult Index()
        {
            var value = context.Abouts.FirstOrDefault();
            return View(value);
        }

		[HttpGet]

		public IActionResult UpdateAboutMe(int id)
		{
			var value = context.Abouts.Find(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateAboutMe(About about)
		{
			context.Abouts.Update(about);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
