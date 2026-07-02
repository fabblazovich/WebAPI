using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM.DTO;
using WPF_MVVM.Model;

namespace WPF_MVVM.Service
{
    public interface IToDoApiService
    {
        Task<List<Todo>> GetTodos();
        Task PostTodos(PostToDoItem postToDoItem);
    }
}
