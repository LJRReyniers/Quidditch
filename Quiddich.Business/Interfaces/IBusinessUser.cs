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
        public bool Check_User(string Username);
        public User get_User(string Username);
        public List<User> Get_Top_3_Scores();
        public string GetPlacementStringForPosititon(int i);
    }
}
