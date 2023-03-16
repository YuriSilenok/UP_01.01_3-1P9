using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JournalApp.Models;


namespace JournalApp.ViewModels
{
    public class MainViewModel 
    {
        public User Autorization(string login, string password)
        {
            var users = Session.Entities.User.ToList().Where(u => u.UserName == login && u.Password == password);
            return Session.CurrentUser = users.Count() == 1 ? users.First() : null;
        }
    }
}
