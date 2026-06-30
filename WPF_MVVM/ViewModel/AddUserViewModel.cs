using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_MVVM.Commands;
using WPF_MVVM.Model;
using WPF_MVVM.View;

namespace WPF_MVVM.ViewModel
{
    internal class AddUserViewModel
    {
        public ICommand AddUserCommand { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }

        public AddUserViewModel()
        {
            AddUserCommand = new RelayCommand(AddUser, CanAddUser);
        }

        private bool CanAddUser(object obj)
        {
            return true;
        }

        private void AddUser(object obj)
        {
            UserManager.AddUser(new User(){ Name = Name, Email = Email });
        }
    }
}
