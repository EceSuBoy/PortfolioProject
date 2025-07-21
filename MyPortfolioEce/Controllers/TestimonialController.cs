using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioEce.DAL.Context;
using MyPortfolioEce.DAL.Entities;
using System.Data;

namespace MyPortfolioEce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        MyPortfolioContext context= new MyPortfolioContext();
        public IActionResult Index()
        {
            var value = context.Testimonials.ToList();
            return View(value);
        }
        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            context.Testimonials.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index"); 
        }
        public IActionResult DeleteTestimonial(int id)
        {
            var value= context.Testimonials.Find(id);
            context.Testimonials.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            context.Testimonials.Update(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
