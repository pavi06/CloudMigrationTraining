namespace TodoApp.Models.DTOs
{
    public class TodoDTO
    {
        public string Title { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }
        public bool Status { get; set; }

        public TodoDTO(string title, string userName, string description, DateTime targetDate, bool status)
        {
            Title = title;
            UserName = userName;
            Description = description;
            TargetDate = targetDate;
            Status = status;
        }
    }
}
