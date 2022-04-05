using Microsoft.AspNetCore.Mvc;
using Quidditch.Data;
using Quidditch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace Quidditch.Controllers
{
    public class LoginController : Controller
    {
        private readonly QuidditchContext _context;
        public LoginController(QuidditchContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
        List<User> UserList = new List<User>();
        UserList = _context.User.ToList();
        ViewData["User"] = UserList;
        return View();
        }
        public IActionResult New()
        {
            List<User> UserList = new List<User>();
            UserList = _context.User.ToList();
            ViewData["User"] = UserList;
            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind("Id,Username,Password,Score")] User user)
        {
            User myUser = _context.User.FirstOrDefault(u => u.Username.Equals(user.Username) && u.Password.Equals(user.Password));
            if (myUser != null)    //User was found
            {
                return RedirectToAction("Index","Home");
                //Console.WriteLine("Login successful");
            }
            else    //User was not found
            {
                return View();
                //Console.WriteLine("Username or Password is incorrect");
            }
            //_context.SaveChanges();
            //return View();
        }
        public IActionResult New([Bind("Id,Username,Password,Score")] User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            List<User> UserList = new List<User>();
            UserList = _context.User.ToList();
            ViewData["User"] = UserList;
            return View();
        }
    }
}
