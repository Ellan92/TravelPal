using System.Collections.Generic;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public static class TravelManager
    {
        public static List<Travel> Travels { get; set; } = new()
        {
            //new Vacation { Destination = "New York", Country = Enums.Country.USA, Travelers = 4, TravelDays = 14, AllInclusive = true },

            //new WorkTrip { Destination = "Stockholm", Country = Enums.Country.Sweden, Travelers = 2, TravelDays = 3, MeetingDetails = "Meeting at 17:30" }

        };

        //public static void addTravel()
        //{

        //}
        public static void removeTravel(Travel travel)
        {
            Travels.Remove(travel);
        }

        public static void GetTravels()
        {
            foreach (User user in UserManager.Users)
            {
                //user.Travels

            }
        }

        //public static Travel GetTravels()
        //{
        //    foreach (var travel in Travels)
        //    {
        //        return travel;
        //    }

        //}
    }
}
