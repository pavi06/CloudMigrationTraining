using TodoApp.Interfaces;
using TodoApp.Models;
using TodoApp.Models.DTOs;

namespace TodoApp.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<string, User> _userRepository;
        public bool UserLoggedIn { get; private set; } = false;
        public string LoggedInUserName { get; private set; }

        public UserService(IRepository<string, User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<bool> Login(LoginDTO loginDTO)
        {
            var user = _userRepository.Get().Result.SingleOrDefault(u => u.UserName == loginDTO.UserName && u.Password == loginDTO.Password);
            if(user != null)
            {
                UserLoggedIn = true;
                LoggedInUserName = user.UserName;
                return true;
            }
            return false;
        }

        public async Task<bool> Register(RegistrationDTO userDTO)
        {
            var user = new User(userDTO.UserName, userDTO.FirstName, userDTO.LastName, userDTO.Password);
            var addedUser = await _userRepository.Add(user);
            if(addedUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
