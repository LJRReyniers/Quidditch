using Quidditch.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quidditch.Data.Interfaces
{
    public interface IDataPost
    {
        public List<Post> Get_Post(int userId);
        public List<Post> ToList_Get_Post(int userId);
        public void Add_Post(Post post);
        public List<Post> Getall_Posts();
    }
}
