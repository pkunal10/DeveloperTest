using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using DeveloperTest.Models;

namespace DeveloperTest.Models
{
    public class DBContextMail: DbContext
    {
        public DBContextMail()
            : base("conStr")
        {

        }
        public DbSet<User> Users{ get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}