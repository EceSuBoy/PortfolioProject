using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using MyPortfolioEce.DAL.Context;

namespace MyPortfolioEce.ViewComponents.LayoutViewComponents
{
	public class _LayoutNavbarComponentPartial : ViewComponent
	{
		MyPortfolioContext context = new MyPortfolioContext();
		public IViewComponentResult Invoke()
		{
			ViewBag.toDoListCount= context.ToDoLists.Where(x=>x.Status==false).Count();
			var values = context.ToDoLists.Where(x=>x.Status==false).ToList();
			return View(values);
		}
	}
}
