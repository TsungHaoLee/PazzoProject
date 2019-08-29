namespace PazzoAPI.Controllers
{
    using Pazzo.DB;
    using Pazzo.User;
    using System;
    using System.Web.Http;

    public class UserController : ApiController
    {
        [HttpGet]
        public bool Get()
        {
            return true;
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
