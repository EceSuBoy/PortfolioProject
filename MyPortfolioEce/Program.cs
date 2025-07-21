using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MyPortfolioEce.DAL.Context;



var builder = WebApplication.CreateBuilder(args);


//  Configure services
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";         // go here if not logged in
        options.AccessDeniedPath = "/AccessDenied"; // go here if role denied
    });

var app = builder.Build();

//  Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//  Add authentication and authorization
app.UseAuthentication(); //  Must come BEFORE UseAuthorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
