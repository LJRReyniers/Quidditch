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
    public class UserTests
    {
        public Mock<IDataUser> MockData()
        {
            var data = new List<User>
            {
                new User {Id = 1, Username = "één", Password = "één", Score = 1},
                new User {Id = 2, Username = "twee", Password = "twee", Score = 2}
            };

            //var mockset = new Mock<DbSet<User>>();

            //mockset.As<IQueryable<User>>().Setup(m => m.Provider).Returns(data.Provider);
            //mockset.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
            //mockset.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
            //mockset.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<IDataUser>();
            mockContext.Setup(c => c.Getall_Users()).Returns(data);

            return mockContext;
        }
        [TestMethod]
        public void Get_All_Users_Test()
        {
            //Arrange
            var mockContext = MockData();

            //Act
            var service = new BusinessUserService(mockContext.Object);
            var users = service.GetAllUsers();

            //Assert
            Assert.AreEqual(2, users.Count);
        }
    }
}
