using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch.Entities.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Titel { get; set; }
        public string Body { get; set; }
    }
}
