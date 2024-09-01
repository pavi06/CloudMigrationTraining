using Microsoft.EntityFrameworkCore;
using TodoApp.Contexts;
using TodoApp.CustomExceptions;
using TodoApp.Interfaces;
using TodoApp.Models;

namespace TodoApp.Repositories
{
    public class TodoRepository : IRepository<long, Todo>
    {
        private TodoContext _context;

        public TodoRepository(TodoContext context)
        {
            _context = context;
        }
        public async Task<Todo> Add(Todo item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Todo> Delete(long key)
        {
            var todoItem = await Get(key);
            if (todoItem != null)
            {
                _context.Remove(todoItem);
                await _context.SaveChangesAsync();
                return todoItem;
            }
            throw new ObjectNotAvailableException("Todo Item not available!");
        }

        public async Task<Todo> Get(long key)
        {
            var todoItem = await _context.Todos.SingleOrDefaultAsync(t => t.Id == key);
            if (todoItem != null)
            {
                return todoItem;
            }
            throw new ObjectNotAvailableException("Todo Item not available!");
        }

        public async Task<IEnumerable<Todo>> Get()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<Todo> Update(Todo item)
        {
            var todo = await Get(item.Id);
            if (todo != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return todo;
            }
            throw new ObjectNotAvailableException("Todo Item not available!");
        }
    }
}
