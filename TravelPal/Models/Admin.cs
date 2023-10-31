using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Interfaces;

namespace TravelPal.Models
{
    public class Admin : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Country { get; set; }

        public List<Travel>? Travels { get; set; }
        public Admin(string username, string password, Country country)
        {
            Username = username;
            Password = password;
            Country = country;
            Travels = null;
        }

    }
}
