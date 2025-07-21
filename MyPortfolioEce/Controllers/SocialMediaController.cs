using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioEce.DAL.Context;
using MyPortfolioEce.DAL.Entities;
using System.Data;

namespace MyPortfolioEce.Controllers
{
	[Authorize(Roles = "Admin")]
	public class SocialMediaController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Index()
        {
            var value = context.SocialMedias.ToList();
            return View(value);
        }
        [HttpGet]
        public IActionResult CreateSocialMedia() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialmedia)
        {
            context.SocialMedias.Add(socialmedia);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = context.SocialMedias.Find(id);
            context.SocialMedias.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateSocialMedia(int id) 
        {
            var value = context.SocialMedias.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialmedia)
        {
            context.SocialMedias.Update(socialmedia);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
