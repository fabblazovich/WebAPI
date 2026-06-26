
namespace WebAPI.Services
{
    public class MaterialToDoService : ITodoService
    {
        private readonly List<TodoItem> _todos = new List<TodoItem>()
        {
            new TodoItem { ID = 1, Title = "Laptop vorbereiten", IsDone = true },
            new TodoItem { ID = 2, Title = "USB-Kabel einpacken", IsDone = false },
            new TodoItem { ID = 3, Title = "Notizbuch mitnehmen", IsDone = false },
            new TodoItem { ID = 4, Title = "Präsentation testen", IsDone = true }
        };

        public bool Create(TodoItem todo)
        {
            if (string.IsNullOrWhiteSpace(todo.Title))
            {
                return false;
            }

            todo.ID = _todos.Count == 0
                ? 1
                : _todos.Max(x => x.ID) + 1;

            _todos.Add(todo);

            return true;
        }

        public bool Delete(int id)
        {
            var todo = _todos.FirstOrDefault(todo => todo.ID == id);
            if (todo is null) return false;
           
            _todos.Remove(todo);
            return true;
        }

        public List<TodoItem> GetAll()
        {
            return _todos;
        }

        public TodoItem? GetById(int id)
        {
            return _todos.FirstOrDefault(todo => todo.ID == id);
        }

        public List<TodoItem> GetDoneTodos()
        {
            return _todos.Where(x => x.IsDone).ToList();
        }

        public List<TodoItem> GetOpenTodos()
        {
            return _todos
                .Where(x => !x.IsDone)
                .ToList();
        }

        public List<string> GetTitles()
        {
            return _todos
                .Select(x => x.Title)
                .ToList();
        }
    }
}
