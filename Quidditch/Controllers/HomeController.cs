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
            ViewBag.UserScore = _userService.GetAllUsers();

            var userId = HttpContext.Session.GetInt32(UserId);
            if (userId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.PostNumber = _postService.get_Post((int)userId).Count;

            ViewBag.Username = HttpContext.Session.GetString(Username);
            ViewBag.UserId = userId;

            return View();
        }
        public IActionResult Score()
        {
            return View();
        }
        public IActionResult Blogpost()
        {
            return View(_postService.GetALL_Posts());
        }
        public IActionResult MyPost()
        {
            var userId = HttpContext.Session.GetInt32(UserId);
            ViewBag.UserId = userId;
            if (userId == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var username = HttpContext.Session.GetString(Username);
            ViewBag.Username = username;

            return View(_postService.ToList_get_Post((int)userId));
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
            _postService.add_Post(post);

            ViewData["Post"] = _postService.get_Post((int)userId);

            return View(_postService.get_Post((int)userId));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
