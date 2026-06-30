using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.DTO;

namespace WebAPI.Services
{
    public class DatabaseToDoService :ITodoService
    {
        private readonly AddDbContext _context;

            public DatabaseToDoService(AddDbContext context)
            {
                _context = context;
            }

            public async Task<TodoItem?> GetById(int id)
            {
                return await _context.Todos.FirstOrDefaultAsync(todo => todo.ID == id);
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

            public async Task<List<TodoItem>> GetDoneTodos()
            {
                return await _context.Todos
                    .Where(todo => todo.IsDone)
                    .ToListAsync();
            }

            public async Task<List<TodoItem>> GetOpenTodos()
            {
                return await _context.Todos
                    .Where(todo => !todo.IsDone)
                    .ToListAsync();
            }

            public async Task<List<string>> GetTitles()
            {
                return await _context.Todos
                    .Select(todo => todo.Title)
                    .ToListAsync();
            }

            public async Task<int> GetMaxId()
            {
                return await _context.Todos.AnyAsync()
                    ? await _context.Todos.MaxAsync(todo => todo.ID)
                    : 0;
            }

            public async Task<List<TodoItem>> SearchByTitle(string text)
            {
                return await _context.Todos
                    .Where(todo => todo.Title.Contains(text))
                    .ToListAsync();
            }

            public async Task<bool> Update(int id, UpdateToDoRequest request)
            {
                var todo = await _context.Todos.FirstOrDefaultAsync(todo => todo.ID == id);

                if (todo == null) return false;

                if (string.IsNullOrWhiteSpace(request.Title)) return false;

                todo.Title = request.Title;
                todo.Description = request.Description;
                todo.IsDone = request.IsDone;

                await _context.SaveChangesAsync();

                return true;
            }

            public async Task<List<TodoItem>> GetAll(bool? isDone, string? search)
            {
                var query = _context.Todos.AsQueryable();

                if (isDone.HasValue)
                {
                    query = query.Where(todo  => todo.IsDone == isDone.Value);
                }

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(todo => todo.Title.Contains(search));
                }

                return await query.ToListAsync();
            }   
    }
}
