using Quidditch.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiddich.Business.Interfaces
{
    public interface IBusinessUser
    {
        public List<User> GetAllUsers();
        public void add_User(User user);
        public User get_User(string Username);
    }
}
