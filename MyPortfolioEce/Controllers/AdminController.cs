using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolioEce.DAL.Context;
using MyPortfolioEce.Models;
using System.IO;
using System.Linq;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    MyPortfolioContext context = new MyPortfolioContext();

    // VIEW-ONLY: GET /Admin/SettingsView
    public IActionResult SettingsView()
    {
        var admin = context.AdminUsers.FirstOrDefault();
        if (admin == null) return NotFound();

        var profile = context.AdminProfiles.FirstOrDefault(p => p.AdminUserID == admin.ID)
                      ?? new MyPortfolioEce.DAL.Entities.AdminProfile();

        var viewModel = new AdminSettingsViewModel
        {
            Name = profile.Name,
            Surname = profile.Surname,
            ExistingProfileImagePath = profile.ProfileImageUrl,
            ExistingCvPath = profile.CvFilePath
        };

        if (TempData["Message"] != null)
            ViewBag.Message = TempData["Message"];

        return View(viewModel);
    }

    // EDIT MODE: GET /Admin/Settings
    public IActionResult Settings()
    {
        var admin = context.AdminUsers.FirstOrDefault();
        if (admin == null) return NotFound();

        var profile = context.AdminProfiles.FirstOrDefault(p => p.AdminUserID == admin.ID)
                      ?? new MyPortfolioEce.DAL.Entities.AdminProfile();

        var viewModel = new AdminSettingsViewModel
        {
            Name = profile.Name,
            Surname = profile.Surname,
            ExistingProfileImagePath = profile.ProfileImageUrl,
            ExistingCvPath = profile.CvFilePath
        };

        return View(viewModel);
    }

    // POST: Admin/Settings
    [HttpPost]
    public IActionResult Settings(AdminSettingsViewModel model)
    {
        var admin = context.AdminUsers.FirstOrDefault();
        if (admin == null) return NotFound();

        var profile = context.AdminProfiles.FirstOrDefault(p => p.AdminUserID == admin.ID);
        if (profile == null)
        {
            profile = new MyPortfolioEce.DAL.Entities.AdminProfile { AdminUserID = admin.ID };
            context.AdminProfiles.Add(profile);
        }

        // PASSWORD VALIDATION
        if (!string.IsNullOrEmpty(model.CurrentPassword) || !string.IsNullOrEmpty(model.NewPassword) || !string.IsNullOrEmpty(model.ConfirmPassword))
        {
            if (string.IsNullOrEmpty(model.CurrentPassword) || model.CurrentPassword != admin.Password)
            {
                ModelState.AddModelError("", "Current password is incorrect.");
                return View(model);
            }

            if (model.NewPassword != model.ConfirmPassword)
            {
                ModelState.AddModelError("", "New password and confirmation do not match.");
                return View(model);
            }

            admin.Password = model.NewPassword;
        }

        // UPDATE PROFILE INFO
        if (!string.IsNullOrWhiteSpace(model.Name))
            profile.Name = model.Name;

        if (!string.IsNullOrWhiteSpace(model.Surname))
            profile.Surname = model.Surname;

        // PROFILE IMAGE UPLOAD
        if (model.ProfileImage != null)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "ProfileImages");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid() + Path.GetExtension(model.ProfileImage.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                model.ProfileImage.CopyTo(fileStream);
            }

            profile.ProfileImageUrl = Path.Combine("Uploads/ProfileImages", uniqueFileName).Replace("\\", "/");
        }

        // CV UPLOAD
        if (model.CvFile != null)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "CvFiles");
            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = Guid.NewGuid() + Path.GetExtension(model.CvFile.FileName);
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                model.CvFile.CopyTo(fileStream);
            }

            profile.CvFilePath = Path.Combine("Uploads/CvFiles", uniqueFileName).Replace("\\", "/");

            // COPY TO STATIC LOCATION (for public CV)
            var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var publicCvPath = Path.Combine(wwwrootPath, "EceSuBoy_CV.pdf");

            System.IO.File.Copy(filePath, publicCvPath, overwrite: true);
        }

        context.SaveChanges();

        TempData["Message"] = "Settings updated successfully!";
        return RedirectToAction("SettingsView");
    }
}
