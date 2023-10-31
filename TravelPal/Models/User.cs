using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Interfaces;
using TravelPal.Managers;
using TravelPal.Windows;

namespace TravelPal.Models
{
    public class User : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Country Country { get; set; }

        public List<Travel>? Travels { get; set; } = new()
        {

        };

        public User()
        {
            
        }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User(string username, string password, Country country)
        {
            Username = username;
            Password = password;
            Country = country;
        }

        public User(string username, string password, Country country, List<Travel> travels)
        {
            Username = username;
            Password = password;
            Country = country;
            Travels = null;
        }

        //public void removeTravel(Travel travel)
        //{

        //    Travels.Remove(travel);
        //}

    }
}
