using Quidditch.Data.Interfaces;
using Quidditch.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Quidditch.Data.Services
{
    public class DataUserService : IDataUser
    {
        private readonly QuidditchContext _context;
        public DataUserService(QuidditchContext context)
        {
            _context = context;
        }
        public User Get_User(string Username)
        {
            return _context.User.Include(x => x.Posts).FirstOrDefault(u => u.Username.Equals(Username));
        }

        public void Add_User(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        public List<User> Getall_Users()
        {
            List<User> UserList = new List<User>();
            UserList = _context.User.ToList();

            return UserList;
        }

        public List<User> GetTop3Scores()
        {
            return _context.User.OrderByDescending(u => u.Score).Take(3).ToList();
        }
    }
}
