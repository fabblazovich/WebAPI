using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVVM.DTO;
using WPF_MVVM.Model;

namespace WPF_MVVM.Service
{
    public class ToDoApiService : IToDoApiService
    {
        private readonly HttpClient _httpClient;

        public ToDoApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Todo>> GetTodos()
        {
            var todos = await _httpClient.GetFromJsonAsync<List<Todo>>("Todos");

            return todos;
        }

        public async Task PostTodos(PostToDoItem postToDoItem)
        {
            var response = await _httpClient.PostAsJsonAsync("Todos", postToDoItem);

            if (response.IsSuccessStatusCode) MessageBox.Show("Success");
        }
    }
}
