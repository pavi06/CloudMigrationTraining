using TodoApp.Models.DTOs;

namespace TodoApp.Interfaces
{
    public interface IUserService
    {
        bool UserLoggedIn { get; }
        string LoggedInUserName { get;}
        public Task<bool> Login(LoginDTO loginDTO);
        public Task<bool> Register(RegistrationDTO userDTO);
    }
}
