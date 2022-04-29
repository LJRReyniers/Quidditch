using Quiddich.Business.Interfaces;
using Quidditch.Data.Interfaces;
using Quidditch.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiddich.Business.Services
{
    public class BusinessPostService : IBusinessPost
    {
        private readonly IDataPost _postService;
        public BusinessPostService(IDataPost postService)
        {
            _postService = postService;
        }
        public List<Post> get_Post(int userId)
        {
            return _postService.Get_Post(userId);
        }
        public List<Post> ToList_get_Post(int userId)
        {
            return _postService.ToList_Get_Post(userId);
        }
        public void add_Post(Post post)
        {
            _postService.Add_Post(post);
        }
        public List<Post> GetALL_Posts()
        {
            return _postService.Getall_Posts();
        }
    }
}
