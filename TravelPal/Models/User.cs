using System.Collections.Generic;
using TravelPal.Interfaces;

namespace TravelPal.Models
{
    public class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string Country { get; set; }

        public List<Travel> Travels { get; set; }


        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User(string username, string password, string country)
        {
            Username = username;
            Password = password;
            Country = country;
        }

        public User(string username, string password, string country, List<Travel> travels)
        {
            Username = username;
            Password = password;
            Country = country;
            Travels = travels;
        }
    }
}
