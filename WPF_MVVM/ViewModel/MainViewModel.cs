using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_MVVM.Commands;
using WPF_MVVM.Model;
using WPF_MVVM.View;

namespace WPF_MVVM.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<User> Users { get; set; }
        public ICommand ShowWindowsCommand { get; set; }

        public ICommand ShowNewWindowsCommand { get; set; }

        public ICommand SearchPlayerCommand { get; set; }   

        public string Name { get; set; }

        public MainViewModel() 
        {
           Users = UserManager.GetUsers();
           ShowWindowsCommand = new RelayCommand(ShowWindow, CanShowWindow);
           ShowNewWindowsCommand = new RelayCommand(ShowNewWindow, CanShowWindow);
           SearchPlayerCommand = new RelayCommand(SearchPlayer, CanSearchPlayer);
        }

        private void SearchPlayer(object obj)
        {
            var list = UserManager.GetUsers();
            var selectedPlayer = list.FirstOrDefault(player => player.Name.Equals(Name));
            if (selectedPlayer == null) return;
            Users.Clear();
            Users.Add(selectedPlayer);
        }

        private bool CanSearchPlayer(object obj)
        {
            return true;
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            AddUser addUserWindow = new AddUser();
            addUserWindow.Show();           
        }

        private void ShowNewWindow(object obj)
        {
            NewWindow newWindow = new NewWindow();
            newWindow.Show();
        }
    }
}
