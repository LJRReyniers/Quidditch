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
        public List<User> GetAllUsers(user)
        {
            return _userService.Getall_Users(user);
        }
    }
}
