using System.Collections.Generic;
using TravelPal.Interfaces;

namespace TravelPal.Models
{
    public class Admin : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }

        public List<Travel> Travels { get; set; }

        public Admin(string username, string password, string country)
        {
            Username = username;
            Password = password;
            Country = country;
        }

    }
}
