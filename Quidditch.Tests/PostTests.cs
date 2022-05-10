using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Quiddich.Business.Services;
using Quidditch.Data;
using Quidditch.Entities.Models;
using Quidditch.Data.Services;
using Quidditch.Data.Interfaces;

namespace Quidditch.Tests
{
    [TestClass]
    public class PostTests
    {
        public Mock<IDataPost> MockData()
        {
            var data = new List<Post>
            {
                new Post {Id = 1, UserId = 1, Titel = "één", Body = "één"},
                new Post {Id = 2, UserId = 2, Titel = "twee", Body = "twee"}
            };

            //var mockset = new Mock<DbSet<Post>>();

            //mockset.As<IQueryable<Post>>().Setup(m => m.Provider).Returns(data.Provider);
            //mockset.As<IQueryable<Post>>().Setup(m => m.Expression).Returns(data.Expression);
            //mockset.As<IQueryable<Post>>().Setup(m => m.ElementType).Returns(data.ElementType);
            //mockset.As<IQueryable<Post>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IDataPost>();
            mockContext.Setup(c => c.Getall_Posts()).Returns(data);

            return mockContext;
        }
        [TestMethod]
        public void Get_All_Posts_Test()
        {
            //Arrange
            var mockContext = MockData();

            //Act
            var service = new BusinessPostService(mockContext.Object);
            var posts = service.GetALL_Posts();

            //Assert
            Assert.AreEqual(2, posts.Count);
        }
    }
}
