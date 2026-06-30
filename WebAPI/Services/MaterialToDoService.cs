
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebAPI.Data;
using WebAPI.DTO;

namespace WebAPI.Services
{
    public class MaterialToDoService : ITodoService
    {
        private readonly AppDbContext _context;

        public MaterialToDoService (AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(TodoItem todo)
        {
            if (string.IsNullOrWhiteSpace(todo.Title))
            {
                return false;
            }

            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var todo = await _context.Todos.FirstOrDefaultAsync(todo => todo.ID == id);
            if (todo is null) return false;
           
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TodoItem>> GetAll()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<List<TodoItem>> GetAll(bool? isDone, string? search)
        {
            var query = _context.Todos.AsQueryable();

            if (isDone.HasValue)
            {
                query = query.Where(todo  => todo.IsDone == isDone);
            }
        
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(todo => todo.Title.Contains(search));
            }

            return await query.ToListAsync();
        }

        public async Task<TodoItem?> GetById(int id)
        {
            return await _context.Todos.FirstOrDefaultAsync(todo => todo.ID == id);
        }

        public async Task<List<TodoItem>> GetDoneTodos()
        {
            return await _context.Todos.Where(todo => todo.IsDone).ToListAsync();
        }

        public async Task<List<TodoItem>> GetOpenTodos()
        {
            return await _context.Todos.Where(todo => !todo.IsDone).ToListAsync();
        }

        public async Task<List<string>> GetTitles()
        {
            return await _context.Todos.Select(todo => todo.Title).ToListAsync();
        }

        public async Task<bool> Update(int id, UpdateToDoRequest request)
        {
            if (request.Title is null) return false;

            var todo = await _context.Todos.FirstOrDefaultAsync(todo => todo.ID == id);

            if (todo is null) return false;

            todo.Title = request.Title;
            todo.Description = request.Description;
            todo.IsDone = request.IsDone;

            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
