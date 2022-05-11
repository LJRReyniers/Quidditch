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
        private Mock<IDataUser> _dataUserMock;
        [TestInitialize]
        public void Setup()
        {
            var data = new List<User>
            {
                new User {Id = 1, Username = "één", Password = "één", Score = 1},
                new User {Id = 2, Username = "twee", Password = "twee", Score = 2}
            };

            var dataUserMock = new Mock<IDataUser>();
            dataUserMock.Setup(c => c.Getall_Users()).Returns(data);
            dataUserMock.Setup(c => c.Get_User("één")).Returns(data.First());

            _dataUserMock = dataUserMock;
        }

        [TestMethod]
        public void Get_All_Users_Test()
        {
            //Arrange

            //Act
            var service = new BusinessUserService(_dataUserMock.Object);
            var users = service.GetAllUsers();
            
            //Assert
            Assert.AreEqual(2, users.Count);
        }
        [TestMethod]
        public void Get_User_Test()
        {
            //Arrange

            //Act
            var service = new BusinessUserService(_dataUserMock.Object);
            User user = service.get_User("één");

            //Assert
            Assert.AreEqual("één", user.Username);
        }
    }
}
