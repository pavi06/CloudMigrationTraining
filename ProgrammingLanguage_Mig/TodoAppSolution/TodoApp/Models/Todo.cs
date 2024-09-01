using System.Runtime.InteropServices;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Models
{
    public class Todo
    {
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string UserName { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public DateTime TargetDate { get; set; }
        public bool Status { get; set; }

        public Todo(string title, string userName, string description, DateTime targetDate, bool status)
        {
            Title = title;
            UserName = userName;
            Description = description;
            TargetDate = targetDate;
            Status = status;
        }

        public Todo(long id, string title, string userName, string description, DateTime targetDate, bool status)
        {
            Id = id;
            Title = title;
            UserName = userName;
            Description = description;
            TargetDate = targetDate;
            Status = status;
        }

        public override int GetHashCode()
        {
            const int prime = 31;
            int result = 1;
            result = prime * result + (int)(Id ^ (Id >> 32));
            return result;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (Todo)obj;
            return Id == other.Id;
        }

    }
}
