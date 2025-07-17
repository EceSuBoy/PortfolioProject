using System.ComponentModel.DataAnnotations;

namespace MyPortfolioEce.DAL.Entities
{
	public class ToDoList
	{
        public int ToDoListId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
