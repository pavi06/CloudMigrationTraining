using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Contexts
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>()
              .HasOne(t => t.User)
              .WithMany(u => u.Todos)
              .HasForeignKey(t => t.UserName)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
