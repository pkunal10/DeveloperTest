using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperTest.Models;
using DeveloperTest.Service;

namespace DeveloperTest.Service
{
    public class HomeService : IHomeService
    {
        DBContextMail context = new DBContextMail();
        public int Login(string emailid, string password)
        {
            var q = context.Users.Where(x => x.EmailId == emailid && x.Password == password).FirstOrDefault();
            if (q == null)
            {
                return 0;
            }
            else
            {
                return q.UserId;
            }
        }
        public User GetUserById(int id)
        {
            return context.Users.Where(x => x.UserId == id).FirstOrDefault();
        }
    }
}