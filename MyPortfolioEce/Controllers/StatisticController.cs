using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioEce.DAL.Context;
using System.Data;

namespace MyPortfolioEce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatisticController : Controller
    {
        MyPortfolioContext context = new MyPortfolioContext();
        public IActionResult Index()
        {
            ViewBag.v1 = context.Skills.Count();
            ViewBag.v2 = context.Messages.Count();
            ViewBag.v3= context.Messages.Where(x =>x.IsRead==false).Count();
            ViewBag.v4= context.Messages.Where(x=>x.IsRead==true).Count(); 
            ViewBag.v5= context.Experiences.Count();
            ViewBag.v6= context.ToDoLists.Count();


            var unreadMessages = context.Messages.Where(x => !x.IsRead).ToList();
            var todoList = context.ToDoLists.ToList();

            ViewBag.UnreadMessages = unreadMessages;
            ViewBag.ToDoList = todoList;


            return View();
        }
        [HttpPost]
        public IActionResult UpdateStatus(int id, bool newStatus)
        {
            var task = context.ToDoLists.FirstOrDefault(x => x.ToDoListId == id);
            if (task != null)
            {
                task.Status = newStatus;
                context.SaveChanges();
            }

            return RedirectToAction("Index"); // or whatever view you're rendering
        }
    }
}
