using Quidditch.Data.Interfaces;
using Quidditch.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quidditch.Data.Services
{
    public class DataUserService : IDataUser
    {
        private readonly QuidditchContext _context;
        public DataUserService(QuidditchContext context)
        {
            _context = context;
        }
        public User Get_User(User user)
        {
            return _context.User.FirstOrDefault(u => u.Username.Equals(user.Username));
        }

        public void Add_User(User user)
        {
            _context.User.Add(user);
        }

        public List<User> Getall_Users(User user)
        {
            List<User> UserList = new List<User>();
            UserList = _context.User.ToList();

            return UserList;
        }
    }
}
