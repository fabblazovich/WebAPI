
using WebAPI.DTO;

namespace WebAPI.Services
{
    public class ToDoService
    {
        private readonly List<TodoItem> _todos = new()
        {
            new TodoItem { ID = 1, Title = "Git lernen", IsDone = true },
            new TodoItem { ID = 2, Title = "REST API lernen", IsDone = false },
            new TodoItem { ID = 3, Title = "Interface verstehen", IsDone = false }
        };

        public List<TodoItem> GetAll()
        {
            return _todos;
        }
        public bool Create(TodoItem todo)
        {
            if (string.IsNullOrEmpty(todo.Title)) return false;

            todo.ID = _todos.Count == 0
                ? 1: _todos.Max(x => x.ID) + 1;

            _todos.Add(todo);
            return true;
        }

        public bool Delete(int id)
        {
            var todo = _todos.FirstOrDefault(x => x.ID == id);
            if (todo is null) return false;

            _todos.Remove(todo);
            return true;
        }

        public TodoItem? GetById(int id)
        {
            return _todos.FirstOrDefault(x => x.ID == id);
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

        public bool Update(int id, UpdateToDoRequest todo)
        {
            throw new NotImplementedException();
        }

        public List<TodoItem> GetAll(bool? isDone, string? search)
        {
            throw new NotImplementedException();
        }
    }
}
