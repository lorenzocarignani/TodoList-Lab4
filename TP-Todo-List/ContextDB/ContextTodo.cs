
using Microsoft.EntityFrameworkCore;
using TP_Todo_List.Data.Entities;

namespace TP_Todo_List.ContextDB
{
    public class ContextTodo : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<TodoItem> TodoItems { get; set; }
        public object User { get; internal set; }

        public ContextTodo(DbContextOptions<ContextTodo> dbContextOptions) : base(dbContextOptions) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = 1,
                    Name = "admin",
                    Email = "admin@gmail.com",
                    Address = "Av.Siempreviva 742"

                });

            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem
                {
                    TodoItemId = 1,
                    Title = "Compras",
                    Description = "Comprar leche",
                    UserId = 1
                });

            modelBuilder.Entity<User>()
                .HasMany(u => u.Items)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId);
        }
    }
}
