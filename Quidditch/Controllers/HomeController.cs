using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quidditch.Data;
using Quidditch.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch.Controllers
{
    public class HomeController : Controller
    {
        private readonly QuidditchContext _context;
        public HomeController(QuidditchContext context)
        {
            _context = context;
        } 
        public IActionResult Index()
        {
            if (TempData.Peek("User") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        public IActionResult Profile()
        {
            List<User> UserList = new List<User>();
            UserList = _context.User.ToList();
            ViewBag.UserScore = UserList;
            List<Post> count = new List<Post>();
            var numbers = _context.Post.Where(p => p.UserId == 0);
            foreach (var number in numbers)
            {
                count.Add(number);
            }
            ViewBag.PostNumber = count.Count();
            if (TempData.Peek("User") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            TempData.Peek("Username");
            return View();
        }
        public IActionResult Score()
        {
            return View();
        }
        public IActionResult Blogpost()
        {
            List<Post> PostList = new List<Post>();
            PostList = _context.Post.ToList();
            ViewData["Post"] = PostList;
            return View();
        }
        public IActionResult MyPost()
        {
            List<Post> PostList = new List<Post>();
            PostList = _context.Post.ToList();
            ViewData["Post"] = PostList;
            TempData.Peek("Username");
            if (TempData.Peek("User") == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
        [HttpPost]
        public IActionResult MyPost([Bind("Id,UserId,Titel,Body")] Post post)

        {
            _context.Post.Add(post);
            _context.SaveChanges();
            List<Post> PostList = new List<Post>();
            PostList = _context.Post.ToList();
            ViewData["Post"] = PostList;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
