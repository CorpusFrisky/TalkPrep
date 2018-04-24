using System;
using Newtonsoft.Json;
using SimpleServerlessSharedLib;
using SimpleServerlessSharedLib.Models;

namespace Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new User[]
            {
                new User(1, "Marilyn McTeague", 42, "Main St."),
                new User(2, "Elmer Bogarty", 13789, "Three Trees Lane"),
                new User(3, "Rufus Corbin", 123, "Willow Road"), 
            };

            Console.Out.WriteLine(JsonConvert.SerializeObject(users));

            Console.In.ReadLine();

                
        }
    }
}
