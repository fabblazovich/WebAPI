using WebAPI.Services;

namespace WebAPI.Services
{
    public interface ITodoService
    {
        List<TodoItem> GetAll();
        TodoItem? GetById(int id);
        bool Create(TodoItem todo);
        bool Delete(int id);

        List<TodoItem> GetDoneTodos();
        List<TodoItem> GetOpenTodos();
        List<string> GetTitles();
    }
}