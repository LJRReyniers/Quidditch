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
using Microsoft.AspNetCore.Http;

namespace Quidditch.Controllers
{
    public class LoginController : Controller
    {
        public const string UserId = "_UserId";

        private readonly QuidditchContext _context;
        public LoginController(QuidditchContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind("Id,Username,Password,Score")] User user)
        {
            User myUser = _context.User.FirstOrDefault(u => u.Username.Equals(user.Username));
            if (myUser != null && BCrypt.Net.BCrypt.Verify(user.Password, myUser.Password))
            {
                TempData["User"] = myUser.Id;
                TempData["Username"] = myUser.Username;
                HttpContext.Session.SetInt32(UserId, myUser.Id);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult New([Bind("Id,Username,Password,Score")] User user)
        {
            string Hash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = Hash;

            _context.User.Add(user);
            _context.SaveChanges();
            List<User> UserList = new List<User>();
            UserList = _context.User.ToList();
            ViewData["User"] = UserList;
            return RedirectToAction("Index", "Login");
        }
    }
}
