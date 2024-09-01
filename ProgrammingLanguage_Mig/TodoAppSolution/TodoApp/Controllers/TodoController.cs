using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.CustomExceptions;
using TodoApp.Interfaces;
using TodoApp.Models;
using TodoApp.Models.DTOs;
using TodoApp.Services;

namespace TodoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly IUserService _userService;


        public TodoController(ITodoService todoService, IUserService userService)
        {
            _todoService = todoService;
            _userService = userService;
        }

        #region AddTodoItem
        [HttpPost("Insert")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> AddItem([FromBody] TodoDTO todoDTO)
        {
            try
            {
                var res = await _todoService.AddTodoItem(todoDTO);
                if (res)
                {
                    return Ok(res);
                }
                throw new Exception("Failed to add item");
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }
        #endregion

        #region DeleteTodoItem
        [HttpPost("Delete")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> DeleteItem([FromBody] long itemId)
        {
            try
            {
                var res = await _todoService.DeleteTodoItem(itemId);
                if (res)
                {
                    return Ok(res);
                }
                throw new Exception("Failed to Delete item");
            }
            catch (ObjectNotAvailableException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }
        #endregion

        #region EditTodoItem
        [HttpPut("Edit")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> EditItem([FromBody] UpdateTodoDTO todoItem)
        {
            try
            {
                if (todoItem == null)
                {
                    throw new Exception("Todo Item is null");
                } 
                var res = await _todoService.UpdateTodoItem(todoItem);
                if (res)
                {
                    return Ok(res);
                }
                throw new Exception("Failed to Update item");
            }
            catch (ObjectNotAvailableException ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }
        #endregion

        #region GetTodoList
        [HttpGet("List")]
        [ProducesResponseType(typeof(List<Todo>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Todo>>> ListItems()
        {
            try
            {
                var res = _todoService.GetAllTodos().Result.Where(t=>t.UserName == _userService.LoggedInUserName).ToList();
                if (res.Count>0)
                {
                    return Ok(res);
                }
                throw new Exception("No items are available");
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorModel(404, ex.Message));
            }
        }
        #endregion
    }
}
