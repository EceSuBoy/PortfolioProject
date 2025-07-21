namespace MyPortfolioEce.DAL.Entities
{
	public class AdminProfile
	{
        public int ID { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string ProfileImageUrl { get; set; } // path or filename
        public string CvFilePath { get; set; }      // path or filename

        public int AdminUserID { get; set; }
        public AdminUser AdminUser { get; set; }
    }
}
