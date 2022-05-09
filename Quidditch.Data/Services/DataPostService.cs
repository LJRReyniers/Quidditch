using Quidditch.Data.Interfaces;
using Quidditch.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quidditch.Data.Services
{
    public class DataPostService : IDataPost
    {
        private readonly QuidditchContext _context;
        public DataPostService(QuidditchContext context)
        {
            _context = context;
        }
        public List<Post> Get_Post(int userId)
        {
           return _context.Post.Where(p => p.UserId == userId).ToList();
        }
        public List<Post> ToList_Get_Post(int userId)
        {
            List<Post> PostLijst = new List<Post>();
            return _context.Post.Where(p => p.UserId == userId).ToList();
        }

        public void Add_Post(Post post)
        {
            _context.Post.Add(post);
            _context.SaveChanges();
        }

        public List<Post> Getall_Posts()
        {
            List<Post> PostList = new List<Post>();
            PostList = _context.Post.ToList();

            return PostList;
        }
    }
}
