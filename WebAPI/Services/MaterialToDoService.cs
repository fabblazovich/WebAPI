
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
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TodoItem> GetAll()
        {
            return _todos;
        }

        public TodoItem? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
