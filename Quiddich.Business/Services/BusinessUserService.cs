using Quiddich.Business.Interfaces;
using Quidditch.Data.Interfaces;
using Quidditch.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiddich.Business.Services
{
    public class BusinessUserService : IBusinessUser
    {
        private readonly IDataUser _userService;
        public BusinessUserService(IDataUser userService)
        {
            _userService = userService;
        }
        public List<User> GetAllUsers()
        {
            return _userService.Getall_Users();
        }
        public void add_User(User user)
        {
            _userService.Add_User(user);
        }
        public User get_User(string Username)
        {
            return _userService.Get_User(Username);
        }
        public List<User> Get_Top_3_Scores()
        {
            return _userService.GetTop3Scores();
        }
    }
}
