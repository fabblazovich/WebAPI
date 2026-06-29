using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.DTO;

namespace WebAPI.Services
{
    public class DatabaseToDoService
    {
        public class DatabaseTodoService : ITodoService
        {
            private readonly AddDbContext _context;

            public DatabaseTodoService(AddDbContext context)
            {
                _context = context;
            }

            public List<TodoItem> GetAll()
            {
                return _context.Todos.ToList();
            }

            public TodoItem? GetById(int id)
            {
                return _context.Todos.FirstOrDefault(todo => todo.ID == id);
            }

            public bool Create(TodoItem todo)
            {
                if (string.IsNullOrWhiteSpace(todo.Title))
                {
                    return false;
                }
 
                _context.Todos.Add(todo);
                _context.SaveChanges();

                return true;
            }

            public bool Delete(int id)
            {
                var todo = _context.Todos.FirstOrDefault(todo => todo.ID == id);

                if (todo is null)
                {
                    return false;
                }

                _context.Todos.Remove(todo);
                _context.SaveChanges();

                return true;
            }

            public List<TodoItem> GetDoneTodos()
            {
                return _context.Todos
                    .Where(todo => todo.IsDone)
                    .ToList();
            }

            public List<TodoItem> GetOpenTodos()
            {
                return _context.Todos
                    .Where(todo => !todo.IsDone)
                    .ToList();
            }

            public List<string> GetTitles()
            {
                return _context.Todos
                    .Select(todo => todo.Title)
                    .ToList();
            }

            public int GetMaxId()
            {
                return _context.Todos.Any()
                    ? _context.Todos.Max(todo => todo.ID)
                    : 0;
            }

            public List<TodoItem> SearchByTitle(string text)
            {
                return _context.Todos
                    .Where(todo => todo.Title.Contains(text))
                    .ToList();
            }

            public bool Update(int id, UpdateToDoRequest request)
            {
                var _todo = _context.Todos.FirstOrDefault(_todo => _todo.ID == id);

                if (_todo == null) return false;

                if (string.IsNullOrEmpty(request.Title)) return false;

                _todo.Title = request.Title;
                _todo.Description = request.Description;
                _todo.IsDone = request.IsDone;

                _context.SaveChanges();
                return true;
            }

            public List<TodoItem> GetAll(bool? isDone, string? search)
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

                return query.ToList();
            }
        }
    }
}
