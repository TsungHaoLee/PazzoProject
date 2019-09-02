namespace Pazzo.User
{
    using Newtonsoft.Json;
    using Pazzo.DB;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class UserService
    {
        private log4net.ILog log = log4net.LogManager.GetLogger("UserService");
        public DB.User GetUserById(Guid userId)
        {
            using (var db = new DB.PazzoDatabaseEntities())
            {
                return db.User.Where(c => c.Id == userId).FirstOrDefault();
            }
        }

        public List<User> GetUsers()
        {
            using (var db = new DB.PazzoDatabaseEntities())
            {
                return db.User.ToList();
            }
        }

        public bool UpdateUser(DB.User user)
        {
            Trace.Write("Start Update User");
            Trace.Write(string.Format("Data:{0}", JsonConvert.SerializeObject(user)));
            if(user == null || user.Id == Guid.Empty)
            {
                return false;
            }
            try
            {
                using (var db = new DB.PazzoDatabaseEntities())
                {
                    var oldData = db.User.Where(c => c.Id == user.Id).FirstOrDefault();
                    if (oldData != null)
                    {
                        db.Entry(oldData).CurrentValues.SetValues(user);
                    }
                    db.SaveChanges();
                    Trace.Write("End Update User");
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                Trace.Write("End Update User");
                return false;
            }
        }

        public bool DeleteUsers()
        {
            Trace.Write("Start Delete Users");
            try
            {
                using (var db = new DB.PazzoDatabaseEntities())
                {
                    var users = db.User.ToList();
                    foreach (var user in users)
                    {
                        db.User.Remove(user);
                    }
                    db.SaveChanges();
                    Trace.Write("End Delete Users");
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                Trace.Write("End Delete Users");
                return false;
            }
        }

        public bool CreateUser(DB.User user)
        {
            Trace.Write("Start Create User");
            Trace.Write(string.Format("Data:{0}", JsonConvert.SerializeObject(user)));
            if (user == null || user.Id == Guid.Empty)
            {
                return false;
            }
            try
            {
                using (var db = new DB.PazzoDatabaseEntities())
                {
                    var oldData = db.User.Where(c => c.Id == user.Id).FirstOrDefault();
                    if (oldData == null)
                    {
                        db.User.Add(user);
                    }
                    db.SaveChanges();
                    Trace.Write("End Create User");
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                Trace.Write("End Create User");
                return false;
            }
        }
        public bool DeleteUserById(Guid userId)
        {
            Trace.Write("Start Delete User");
            Trace.Write(string.Format("Data:{0}", userId));
            if (userId == Guid.Empty)
            {
                return false;
            }
            try
            {
                using (var db = new DB.PazzoDatabaseEntities())
                {
                    var oldData = db.User.Where(c => c.Id == userId).FirstOrDefault();
                    if (oldData != null)
                    {
                        db.User.Remove(oldData);
                    }
                    db.SaveChanges();
                    Trace.Write("End Delete User");
                    return true;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
                Trace.Write("End Delete User");
                return false;
            }
        }
    }
}
