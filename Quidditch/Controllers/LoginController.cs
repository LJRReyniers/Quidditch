using Microsoft.AspNetCore.Mvc;
using Quidditch.Data;
using Quidditch.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Quiddich.Business.Interfaces;

namespace Quidditch.Controllers
{
    public class LoginController : Controller
    {
        private readonly IBusinessUser _userService;
        private readonly IBusinessPost _postService;

        public const string UserId = "_UserId";
        public const string Username = "_Username";

        private readonly QuidditchContext _context;
        public LoginController(IBusinessUser userService, IBusinessPost postService)
        {
            _userService = userService;
            _postService = postService;
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
            User myUser = _userService.get_User(user.Username);
            if (myUser != null && BCrypt.Net.BCrypt.Verify(user.Password, myUser.Password))
            {
                HttpContext.Session.SetString(Username, myUser.Username);
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

            _userService.add_User(user);

            ViewData["User"] = _userService.GetAllUsers();

            return RedirectToAction("Index", "Login");
        }
    }
}
