using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_App.Model;

namespace Todo_App.ViewModel
{
    internal class ToDoViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ToDoItem> Todos { get; } = new();

        public string NewTitle = string.Empty;
        
        public ToDoViewModel() 
        {
            Todos.Add(new ToDoItem { ID = 1, Title = "WPF lernen", IsDone = false });
            Todos.Add(new ToDoItem { ID = 2, Title = "MVVM verstehen", IsDone = true });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
