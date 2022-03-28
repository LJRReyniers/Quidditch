using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Quidditch.Models
{
    public class User
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Titel { get; set; }
        public string Body { get; set; }
    }
}
