using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public List<Todo> Todos { get; set; }

        public User(string userName, string firstName, string lastName, string password)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
        }
    }
}
