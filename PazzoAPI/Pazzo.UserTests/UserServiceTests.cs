using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pazzo.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pazzo.User.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        [TestMethod()]
        public void GetUserByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetUsersTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateUserTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateUserTest()
        {
            DB.User user = new DB.User();
            user.Id = Guid.NewGuid();
            user.Name = "TH.Lee1";
            UserService userService = new UserService();
            Assert.IsTrue(userService.CreateUser(user));
            user.Id = Guid.NewGuid();
            user.Name = "TH.Lee2";
            Assert.IsTrue(userService.CreateUser(user));
            user.Id = Guid.NewGuid();
            user.Name = "TH.Lee3";
            Assert.IsTrue(userService.CreateUser(user));
        }

        [TestMethod()]
        public void DeleteUserByIdTest()
        {
            UserService userService = new UserService();
            var users = userService.GetUsers();
            foreach (var user in users)
            {
                Assert.IsTrue(userService.DeleteUserById(user.Id));
            }
        }
    }
}