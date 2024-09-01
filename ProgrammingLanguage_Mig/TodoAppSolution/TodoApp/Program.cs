using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TodoApp.Contexts;
using TodoApp.Interfaces;
using TodoApp.Models;
using TodoApp.Repositories;
using TodoApp.Services;

namespace TodoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region CORS
            builder.Services.AddCors(opts =>
            {
                opts.AddPolicy("MyCors", options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            #endregion

            #region Context
            builder.Services.AddDbContext<TodoContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
                );
            #endregion

            #region Repositories
            builder.Services.AddSingleton<IRepository<string, User>, UserRepository>();
            builder.Services.AddSingleton<IRepository<long, Todo>, TodoRepository>();
            #endregion

            #region Services
            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<ITodoService, TodoService>();
            #endregion

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MyCors");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
