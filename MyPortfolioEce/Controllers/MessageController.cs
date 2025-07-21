using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioEce.DAL.Context;
using MyPortfolioEce.DAL.Entities;
using System.Data;

namespace MyPortfolioEce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MessageController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Inbox()
        {
            var values= context.Messages.ToList();
            return View(values);
        }
        public IActionResult ChangeIsReadToTrue(int id)
        {
            var value = context.Messages.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        public IActionResult ChangeIsReadToFalse(int id)
        {
            var value = context.Messages.Find(id);
            value.IsRead=false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        public IActionResult DeleteMessage(int id)
        {
            var value = context.Messages.Find(id);
            context.Messages.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }
        public IActionResult MessageDetail(int id)
        {
            var value = context.Messages.Find(id);
            if (value == null)
                return NotFound();

            // ✅ Mark as read if not already
            if (!value.IsRead)
            {
                value.IsRead = true;
                context.SaveChanges();
            }

            return View(value);
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            if (string.IsNullOrWhiteSpace(message.NameSurname) || string.IsNullOrWhiteSpace(message.Email))
            {
                return BadRequest("Required fields missing.");
            }

            message.SendDate = DateTime.Now;
            message.IsRead = false;
            context.Messages.Add(message);
            context.SaveChanges();

            return Content("Success"); // Response for AJAX
        }





    }
}
