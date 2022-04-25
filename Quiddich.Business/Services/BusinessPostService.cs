using Quiddich.Business.Interfaces;
using Quidditch.Data.Interfaces;
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
    }
}
