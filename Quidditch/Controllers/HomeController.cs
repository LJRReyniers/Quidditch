using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Quiddich.Business.Interfaces;
using Quidditch.Data;
using Quidditch.Entities.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBusinessUser _userService;
        private readonly IBusinessPost _postService;

        public const string UserId = "_UserId";
        public const string Username = "_Username";

        private readonly QuidditchContext _context;
        public HomeController(IBusinessUser userService, IBusinessPost postService)
        {
            _userService = userService;
            _postService = postService;
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
            User user = new User();
            user.Score = Convert.ToInt32(_userService.GetAllUsers());

            user.Id = (int)HttpContext.Session.GetInt32(UserId);
            if (user.Id == null)
            {
                return RedirectToAction("Index", "Login");
            }
            //user.Number = user.Posts.Count;
            user.Username = HttpContext.Session.GetString(Username);
            return View(user);
        }
        public IActionResult Score()
        {
            User user = new User();
            user.Score = _userService.Get_Top_3_Scores()[0].Score;

            return View(user);
        }
        public IActionResult Blogpost()
        {
            return View(_postService.GetALL_Posts());
        }
        public IActionResult MyPost()
        {
            User user = new User();
            user.Id = (int)HttpContext.Session.GetInt32(UserId);

            if (user.Id == null)
            {
                return RedirectToAction("Index", "Login");
            }
            user.Posts = _postService.ToList_get_Post((int)user.Id);
            user.Username = HttpContext.Session.GetString(Username);
            return View(user);
        }
        [HttpPost]
        public IActionResult MyPost([Bind("Id,UserId,Titel,Body")] Post post)

        {
            User user = new User();
            user.Id = (int)HttpContext.Session.GetInt32(UserId);
            if (user.Id == null)
            {
                return RedirectToAction("Index", "Login");
            }

            post.UserId = (int)user.Id;
            _postService.add_Post(post);

            user.Posts = _postService.get_Post((int)user.Id);

            return View(user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
