
namespace WebAPI.Services
{
    public class ToDoService : ITodoService
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
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public TodoItem? GetById(int id)
        {
            throw new NotImplementedException();
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
