namespace TodoApp.Models.DTOs
{
    public class TodoReturnDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }
        public bool Status { get; set; }

        public TodoReturnDTO(long id, string title, string userName, string description, DateTime targetDate, bool status)
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
