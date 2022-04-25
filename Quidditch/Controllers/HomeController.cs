using Microsoft.AspNetCore.Http;
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
        public const string UserId = "_UserId";
        public const string Username = "_Username";

        private readonly QuidditchContext _context;
        public HomeController(QuidditchContext context)
        {
            _context = context;
        } 
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32(UserId);
            if (userId == null)
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

            var userId = HttpContext.Session.GetInt32(UserId);
            if (userId == null)
            {
                return RedirectToAction("Index", "Login");
            }
            var numbers = _context.Post.Where(p => p.UserId == userId);
            foreach (var number in numbers)
            {
                count.Add(number);
            }
            ViewBag.PostNumber = count.Count();

            var username = HttpContext.Session.GetString(Username);
            ViewBag.Username = username;
            ViewBag.UserId = userId;

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
            List<Post> PostLijst = new List<Post>();

            var userId = HttpContext.Session.GetInt32(UserId);
            ViewBag.UserId = userId;
            if (userId == null)
            {
                return RedirectToAction("Index", "Login");
            }
            PostLijst = _context.Post.Where(p => p.UserId == userId).ToList();
            ViewData["Post"] = PostLijst;

            var username = HttpContext.Session.GetString(Username);
            ViewBag.Username = username;

            return View();
        }
        [HttpPost]
        public IActionResult MyPost([Bind("Id,UserId,Titel,Body")] Post post)

        {
            var userId = HttpContext.Session.GetInt32(UserId);
            ViewBag.UserId = userId;
            if (userId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            post.UserId = (int)userId;
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
