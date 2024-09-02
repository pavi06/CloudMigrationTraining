using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models.DTOs
{
    public class RegistrationDTO
    {
        [Required(ErrorMessage = "First name cannot be empty")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name cannot be empty")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "User name cannot be empty")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
    }
}
