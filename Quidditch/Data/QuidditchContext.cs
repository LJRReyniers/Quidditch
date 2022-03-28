using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quidditch.Models;

namespace Quidditch.Data
{
    public class QuidditchContext : DbContext
    {
        public QuidditchContext(DbContextOptions<QuidditchContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }

    }
}
