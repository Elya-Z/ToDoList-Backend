using Microsoft.EntityFrameworkCore;
using ToDoList.Api.Models;

namespace ToDoList.Api.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<ToDoItem> ToDoItem => Set<ToDoItem>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ToDoItem>().HasKey(e=>e.Id);
            modelBuilder.Entity<ToDoItem>().Property(e => e.Description).IsRequired();
            modelBuilder.Entity<ToDoItem>().Property(e => e.IsCompleted).IsRequired();

        }

    }
}
