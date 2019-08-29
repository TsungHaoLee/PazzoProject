namespace PazzoAPI.Controllers
{
    using Pazzo.DB;
    using Pazzo.User;
    using System;
    using System.Collections.Generic;
    using System.Web.Http;

    public class UserController : ApiController
    {
        [HttpGet]
        public List<User> Get()
        {
            UserService service = new UserService();
            return service.GetUsers();
        }
        [HttpGet]
        [Route("api/User/{userId}")]
        public User User(Guid userId)
        {
            UserService service = new UserService();
            return service.GetUserById(userId);
        }
        [HttpPut]
        public bool UpdateUser(User user)
        {
            UserService service = new UserService();
            return service.UpdateUser(user);
        }
        [HttpDelete]
        [Route("api/User/{userId}")]
        public bool DeleteUserById(Guid userId)
        {
            UserService service = new UserService();
            return service.DeleteUserById(userId);
        }
        [HttpPost]
        public bool CreateUser(User user)
        {
            UserService service = new UserService();
            return service.CreateUser(user);
        }
    }
}
