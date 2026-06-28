using WebAPI.Data;

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
        }
    }
}
