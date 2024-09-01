using Microsoft.EntityFrameworkCore;
using TodoApp.Contexts;
using TodoApp.CustomExceptions;
using TodoApp.Interfaces;
using TodoApp.Models;

namespace TodoApp.Repositories
{
    public class UserRepository : IRepository<string, User>
    {
        protected readonly TodoContext _context;

        public UserRepository(TodoContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> Delete(string key)
        {
            var user = await Get(key);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new ObjectNotAvailableException("User not available!");
        }

        public async Task<User> Get(string key)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == key);
            if (user != null)
            {
                return user;
            }
            throw new ObjectNotAvailableException("User not available!");
        }

        public async Task<IEnumerable<User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Update(User item)
        {
            var user = await Get(item.UserName);
            if (user != null)
            {
                _context.Update(item);
                await _context.SaveChangesAsync();
                return user;
            }
            throw new ObjectNotAvailableException("User not available!");
        }
    }
}
