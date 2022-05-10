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
        private Mock<IDataPost> _dataPostMock;
        [TestInitialize]
        public void Setup()
        {
            var data = new List<Post>
            {
                new Post {Id = 1, UserId = 1, Titel = "één", Body = "één"},
                new Post {Id = 2, UserId = 2, Titel = "twee", Body = "twee"}
            };

            var dataPostMock = new Mock<IDataPost>();
            dataPostMock.Setup(c => c.Getall_Posts()).Returns(data);

            _dataPostMock = dataPostMock;
        }

        [TestMethod]
        public void Get_All_Posts_Test()
        {
            //Arrange

            //Act
            var service = new BusinessPostService(_dataPostMock.Object);
            var posts = service.GetALL_Posts();

            //Assert
            Assert.AreEqual(2, posts.Count);
        }
    }
}
