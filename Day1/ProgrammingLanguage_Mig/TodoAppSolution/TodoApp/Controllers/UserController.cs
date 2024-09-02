using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Interfaces;
using TodoApp.Models;
using TodoApp.Models.DTOs;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyCors")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #region UserLogin
        [HttpPost("Login")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<bool>> Login([FromBody] LoginDTO userLoginDTO)
        {
            try
            {
                var res = await _userService.Login(userLoginDTO);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return Unauthorized(new ErrorModel(401, ex.Message));
            }
        }
        #endregion

        #region UserRegistration
        [HttpPost("Register")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Register([FromBody] RegistrationDTO userDTO)
        {
            try
            {
                var user = await _userService.Register(userDTO);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }
        #endregion
    }
}
