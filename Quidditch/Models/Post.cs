﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quidditch.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Score { get; set; }
    }
}
