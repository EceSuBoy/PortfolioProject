using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioEce.DAL.Context;
using MyPortfolioEce.DAL.Entities;
using System.Data;

namespace MyPortfolioEce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExperienceController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult ExperienceList()
        {
            var values = context.Experiences.ToList();
            return View(values);
        }
        [HttpGet] //DIREKT CALISIR
        public IActionResult CreateExperience()
        {
            return View();
        }
        [HttpPost] //BUTON TETIKLENDIGI ZAMAN CALISIR
        public IActionResult CreateExperience(Experience experience) 
        {
            context.Experiences.Add(experience);
                context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

        public IActionResult DeleteExperience(int id)
        {
            var value = context.Experiences.Find(id);
            context.Experiences.Remove(value);
            context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }

        [HttpGet]

        public IActionResult UpdateExperience(int id)
        {
            var value = context.Experiences.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            context.Experiences.Update(experience);
            context.SaveChanges();
            return RedirectToAction("ExperienceList");
        }
    }
}
