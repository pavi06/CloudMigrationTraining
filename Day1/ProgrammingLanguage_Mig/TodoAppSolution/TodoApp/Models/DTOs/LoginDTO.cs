using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "User name cannot be empty")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
    }
}
