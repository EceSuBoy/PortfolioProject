using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioEce.DAL.Context;
using MyPortfolioEce.DAL.Entities;
using System.ComponentModel;
using System.Data;

namespace MyPortfolioEce.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactsController : Controller
	{
		MyPortfolioContext context = new MyPortfolioContext();
		public IActionResult Index()
		{
			var value = context.Contacts.FirstOrDefault();
			return View(value);
		}
		[HttpGet]
		public IActionResult UpdateContact(int id)
		{
			var value = context.Contacts.Find(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateContact(Contact contact) 
		{
			context.Contacts.Update(contact);
			context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
