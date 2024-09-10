using Microsoft.EntityFrameworkCore;
using ToDoList.Common.Models;

namespace ToDoList.Common.Data
{
    internal class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDoItem>().HasKey(e=>e.Id);
            modelBuilder.Entity<ToDoItem>().Property(e => e.Description).IsRequired();
            modelBuilder.Entity<ToDoItem>().Property(e => e.IsCompleted).IsRequired();

        }
    }
}
