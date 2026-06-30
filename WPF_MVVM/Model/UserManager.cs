using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM.View;

namespace WPF_MVVM.Model
{
    public class UserManager
    {
        public static ObservableCollection<User> _DatabaseUser = new ObservableCollection<User>()
        {
            new User("Markus", "markus@example.com"),
            new User("Peter", "peter@example.com"),
            new User("Lukas", "lukas@example.com")
        };

        public static void AddUser(User user)
        { 
            _DatabaseUser.Add(user);
        }

        public static ObservableCollection<User> GetUsers()
        {
            return _DatabaseUser;
        }
    }
}
