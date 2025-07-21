using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MyPortfolioEce.Models;
using Microsoft.EntityFrameworkCore;
using MyPortfolioEce.DAL.Context;

namespace MyPortfolioEce.Controllers
{
	public class LoginController : Controller
	{
        private readonly MyPortfolioContext _context;

        public LoginController()
        {
            _context = new MyPortfolioContext(); // Created directly without dependency injection
        }
        [HttpGet]
        public IActionResult Index()
		{
			return View(); // This shows the login form
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
                // Check user from database
                var user = _context.AdminUsers
                    .FirstOrDefault(x => x.Username == model.Username && x.Password == model.Password);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, "Admin")
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
					var principal = new ClaimsPrincipal(identity);

					await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

					return RedirectToAction("Index", "Statistic"); // Your admin panel
				}

				ModelState.AddModelError("", "Invalid username or password");
			}

			return View(model);
		}

		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Index");
		}
	}
}
