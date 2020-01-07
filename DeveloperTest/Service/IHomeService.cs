using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DeveloperTest.Models;

namespace DeveloperTest.Service
{
    public interface IHomeService
    {
        int Login(string emailid, string password);
        User GetUserById(int id);
    }
}