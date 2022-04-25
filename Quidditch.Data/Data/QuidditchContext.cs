using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Quidditch.Data
{
    public class QuidditchContext : DbContext
    {
        public QuidditchContext(DbContextOptions<QuidditchContext> options)
            : base(options)
        {
        }

        public DbSet<Quidditch.Entities.Models.User> User { get; set; }
        public DbSet<Quidditch.Entities.Models.Post> Post { get; set; }

    }
}
