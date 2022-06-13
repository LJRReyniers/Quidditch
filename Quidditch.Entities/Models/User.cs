using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Quidditch.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Score { get; set; }
        // lijst van post maken en hierin zetten
        public List<Post> Posts { get; set; }
    }
}
