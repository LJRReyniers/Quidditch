using Quidditch.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quidditch.Data.Interfaces
{
    public interface IDataUser
    {
        public User Get_User(User user);
        public void Add_User(User user);
        public List<User> Getall_Users(User user);
    }
}
