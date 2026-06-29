using WebAPI.DTO;
using WebAPI.Services;

namespace WebAPI.Services
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetAll(bool? isDone, string? search);
        Task<TodoItem?> GetById(int id);
        Task<bool> Create(TodoItem todo);
        Task<bool> Delete(int id);
        Task<List<TodoItem>> GetDoneTodos();
        Task<List<TodoItem>> GetOpenTodos();
        Task<List<string>> GetTitles();
        Task<bool> Update(int id, UpdateToDoRequest todo);
    }
}