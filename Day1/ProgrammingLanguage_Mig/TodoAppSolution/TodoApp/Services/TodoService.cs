using System.Numerics;
using TodoApp.CustomExceptions;
using TodoApp.Interfaces;
using TodoApp.Models;
using TodoApp.Models.DTOs;

namespace TodoApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly IRepository<long, Todo> _todoRepository;

        public TodoService(IRepository<long, Todo> todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public async Task<bool> AddTodoItem(TodoDTO todoDTO)
        {
            var dto = new Todo(todoDTO.Title, todoDTO.UserName, todoDTO.Description, todoDTO.TargetDate, todoDTO.Status);
            var res = await _todoRepository.Add(dto);
            if(res != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteTodoItem(long todoId)
        {
            try
            {
                var dto = await _todoRepository.Delete(todoId);
                if (dto != null)
                {
                    return true;
                }
                return false;
            }
            catch(ObjectNotAvailableException e) {
                throw;
            }
        }

        public async Task<List<TodoReturnDTO>> GetAllTodos()
        {
            var todos = _todoRepository.Get().Result.ToList();
            var result = new List<TodoReturnDTO>();
            foreach (var item in todos)
            {
                result.Add(new TodoReturnDTO(item.Id, item.Title, item.UserName, item.Description, item.TargetDate, item.Status));
            }
            return result;
        }

        public async Task<TodoReturnDTO> GetTodoItem(long todoId)
        {
            try
            {
                var todo = await _todoRepository.Get(todoId);
                return new TodoReturnDTO(todo.Id, todo.Title, todo.UserName, todo.Description, todo.TargetDate, todo.Status);
            }
            catch(ObjectNotAvailableException e)
            {
                throw;
            }
        }

        public async Task<bool> UpdateTodoItem(UpdateTodoDTO todoItem)
        {
            try
            {
                var todo = await _todoRepository.Update(new Todo(todoItem.Id,todoItem.Title,todoItem.UserName, todoItem.Description, todoItem.TargetDate, todoItem.Status));
                if (todo != null)
                {
                    return true;
                }
                return false;
            }
            catch(ObjectNotAvailableException e)
            {
                throw;
            }
            
        }
    }
}
