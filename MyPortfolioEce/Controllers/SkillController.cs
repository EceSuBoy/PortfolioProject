using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioEce.DAL.Context;
using MyPortfolioEce.DAL.Entities;
using System.Data;

namespace MyPortfolioEce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
	{
		MyPortfolioContext context = new MyPortfolioContext();
		public IActionResult Index()
		{
			var value = context.Skills.ToList();
			return View(value);
		}
		[HttpGet]
		public IActionResult CreateSkill() 
		{
			return View();	
		}
		[HttpPost]
		public IActionResult CreateSkill(Skill skill)
		{
			context.Skills.Add(skill);
			context.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult DeleteSkill(int id)
		{
			var value = context.Skills.Find(id);
			context.Skills.Remove(value);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult UpdateSkill(int id)
		{
            var value = context.Skills.Find(id);
            return View(value);
        }
		[HttpPost]
		public IActionResult UpdateSkill(Skill skill)
		{
			context.Skills.Update(skill);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
