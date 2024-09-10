using Microsoft.EntityFrameworkCore;
using ToDoList.Api.Data;
using ToDoList.Api.Models;

namespace ToDoList.Api.Repositories
{
    public class ToDoItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ToDoItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ToDoItem?> GetByIdAsync(int id) 
        {
            return await _context.ToDoItem.SingleOrDefaultAsync(toDoItem => toDoItem.Id == id);        

        }
        public async Task<IEnumerable<ToDoItem?>> GetAllAsync()
        {
            return await _context.ToDoItem.ToListAsync();
        }

        public async Task UpdateAsync(ToDoItem model)
        {
           _context.ToDoItem.Update(model);
           await _context.SaveChangesAsync();
        }
        
        public async Task AddAsync(ToDoItem model)
        {
            
            var lastItem = await _context.ToDoItem
                       .OrderByDescending(p => p.Id)
                       .FirstOrDefaultAsync();
            model.Id = lastItem.Id + 1;
            await _context.ToDoItem.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var model = await GetByIdAsync(id);
            if (model == null) 
            {
                return;
            }
            _context.Remove(model);
            await _context.SaveChangesAsync();

        }
    }
}
