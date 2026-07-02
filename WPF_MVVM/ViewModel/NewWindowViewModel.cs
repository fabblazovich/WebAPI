using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM.Model;
using WPF_MVVM.Service;

namespace WPF_MVVM.ViewModel
{
    public class NewWindowViewModel
    {
        private readonly ToDoApiService _toDoApiService;

        public ObservableCollection<Todo> Todos { get; set; }

        public NewWindowViewModel() 
        {
            Todos = new ObservableCollection<Todo>();

            HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7005/api/")
            };

            _toDoApiService= new ToDoApiService(httpClient);

            LoadTodos();
        }

        private async Task LoadTodos()
        {
            var todos = await _toDoApiService.GetTodos();
            Todos.Clear();
            foreach(var todo in todos) Todos.Add(todo);
        }
    }
}
