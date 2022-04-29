using Quidditch.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiddich.Business.Interfaces
{
    public interface IBusinessPost
    {
        public List<Post> get_Post(int userId);
        public List<Post> ToList_get_Post(int userId);
        public void add_Post(Post post);
        public List<Post> GetALL_Posts();
    }
}
