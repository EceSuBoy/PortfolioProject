namespace MyPortfolioEce.DAL.Entities
{
    public class AdminUser
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
        public string Role { get; set; } = "Admin";
    }
}
