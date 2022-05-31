using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch.Entities.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; } // User ID niet hier zetten, maar lijst van post maken in user
        public string Titel { get; set; }
        public string Body { get; set; }
    }
}
