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
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Score()
        {
            return View();
        }
        public IActionResult Blogpost()
        {
            return View();
        }
        public IActionResult MyPost()

        {
            return View();
        }
        [HttpPost]
        public IActionResult MyPost([Bind("Id,UserId,Titel,Body")] Post post)

        {
            _context.Post.Add(post);
            _context.SaveChanges();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
