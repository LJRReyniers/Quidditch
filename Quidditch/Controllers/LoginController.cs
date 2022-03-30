using Microsoft.AspNetCore.Mvc;
using Quidditch.Data;
using Quidditch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return View();
        }
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New([Bind("Id,Username,Password,Score")] User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return View();
        }
    }
}
