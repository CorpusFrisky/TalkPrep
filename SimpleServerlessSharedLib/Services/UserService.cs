using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleServerlessSharedLib.Models;

namespace SimpleServerlessSharedLib.Services
{
    class UserService
    {
        static readonly List<User> Users = new List<User>
        {
            new User(1, "Marilyn McTeague", 42, "Main St."),
            new User(2, "Elmer Bogarty", 13789, "Three Trees Lane"),
            new User(3, "Rufus Corbin", 123, "Willow Road"),
        };

        public User GetUser(int id)
        {
            return Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
