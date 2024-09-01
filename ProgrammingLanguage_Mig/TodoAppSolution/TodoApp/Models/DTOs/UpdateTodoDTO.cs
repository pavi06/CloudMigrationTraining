using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models.DTOs
{
    public class UpdateTodoDTO
    {
        [Required(ErrorMessage ="Id should not be null")]
        public long Id { get; set; }

        [Required(ErrorMessage = "Title should not be null")]
        public string Title { get; set; }

        [Required(ErrorMessage = "UserName should not be null")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Description should not be null")]
        public string Description { get; set; }

        [Required(ErrorMessage = "TargetDate should not be null")]
        public DateTime TargetDate { get; set; }

        [Required(ErrorMessage = "Status should not be null")]
        public bool Status { get; set; }

        public UpdateTodoDTO(long id, string title, string userName, string description, DateTime targetDate, bool status)
        {
            Id = id;
            Title = title;
            UserName = userName;
            Description = description;
            TargetDate = targetDate;
            Status = status;
        }
    }
}
