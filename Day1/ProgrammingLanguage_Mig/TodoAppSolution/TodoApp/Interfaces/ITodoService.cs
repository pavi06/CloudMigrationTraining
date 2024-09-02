using System;
using TodoApp.Models;
using TodoApp.Models.DTOs;

namespace TodoApp.Interfaces
{
    public interface ITodoService
    {
        public Task<bool> AddTodoItem(TodoDTO todoDTO);
        public Task<TodoReturnDTO> GetTodoItem(long todoId);
        public Task<List<TodoReturnDTO>> GetAllTodos();
        public Task<bool> DeleteTodoItem(long todoId);
        public Task<bool> UpdateTodoItem(UpdateTodoDTO todoItem);
    }
}
