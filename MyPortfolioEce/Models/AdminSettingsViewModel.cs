using Microsoft.AspNetCore.Http;


namespace MyPortfolioEce.Models
{
    public class AdminSettingsViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public IFormFile ProfileImage { get; set; }
        public IFormFile CvFile { get; set; }

        public string ExistingProfileImagePath { get; set; }
        public string ExistingCvPath { get; set; }

        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
