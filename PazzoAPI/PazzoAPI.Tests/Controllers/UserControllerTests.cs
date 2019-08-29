using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pazzo.DB;
using PazzoAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PazzoAPI.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void GetTest()
        {
            RestSharp.RestClient clinet = new RestSharp.RestClient("http://localhost:50235/api/user");
            RestSharp.RestRequest request = new RestSharp.RestRequest(RestSharp.Method.GET);
            List<User> users = new List<User>();
            users = clinet.Execute<List<User>>(request).Data;
            Assert.IsTrue(users.Exists(u => u.Name.Equals("TH.Lee")));
        }

        [TestMethod()]
        public void UserTest()
        {
            RestSharp.RestClient client = new RestSharp.RestClient("http://localhost:50235/api/user");
            RestSharp.RestRequest request = new RestSharp.RestRequest(RestSharp.Method.GET);
            List<User> users = new List<User>();
            users = client.Execute<List<User>>(request).Data;
            if(users == null || users.Count == 0)
            {
                Assert.Fail();
            }
            var user = users.FirstOrDefault();
            var url = string.Format("http://localhost:50235/api/user/{0}", user.Id);
            client = new RestSharp.RestClient(url);
            request = new RestSharp.RestRequest(RestSharp.Method.GET);
            var respones = client.Execute<User>(request);
            Assert.IsTrue(respones.Data.Name.Equals("TH.Lee"));
        }

        [TestMethod()]
        public void UpdateUserTest()
        {
            RestSharp.RestClient client = new RestSharp.RestClient("http://localhost:50235/api/user");
            RestSharp.RestRequest request = new RestSharp.RestRequest(RestSharp.Method.GET);
            List<User> users = new List<User>();
            users = client.Execute<List<User>>(request).Data;
            if (users == null || users.Count == 0)
            {
                Assert.Fail();
            }
            var user = users.FirstOrDefault();
            
            var updateUser = user;
            updateUser.Phone = "2500";
            client = new RestSharp.RestClient("http://localhost:50235/api/user/");
            request = new RestSharp.RestRequest(RestSharp.Method.PUT);
            request.AddJsonBody(updateUser);
            var responesUpdate = client.Execute<bool>(request);
            Assert.IsTrue(responesUpdate.Data);
        }

        [TestMethod()]
        public void DeleteUserByIdTest()
        {
            RestSharp.RestClient clinet = new RestSharp.RestClient("http://localhost:50235/api/user");
            RestSharp.RestRequest request = new RestSharp.RestRequest(RestSharp.Method.GET);
            List<User> users = new List<User>();
            users = clinet.Execute<List<User>>(request).Data;

            User user = users.FirstOrDefault();
            if (user == null)
            {
                Assert.Fail();
            }
            var url = string.Format("http://localhost:50235/api/user/{0}", user.Id);
            clinet = new RestSharp.RestClient(url);
            request = new RestSharp.RestRequest(RestSharp.Method.DELETE);
            
            var response = clinet.Execute<bool>(request);
            Assert.IsTrue(response.Data);
        }

        [TestMethod()]
        public void CreateUserTest()
        {
            RestSharp.RestClient clinet = new RestSharp.RestClient("http://localhost:50235/api/user");
            RestSharp.RestRequest request = new RestSharp.RestRequest(RestSharp.Method.POST);
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Address = "123",
                Name = "TH.Lee",
                Phone = "0901293"
            };
            request.AddJsonBody(user);
            var isSuccess = clinet.Execute<bool>(request);
            Assert.IsTrue(isSuccess.Data);
        }
    }
}