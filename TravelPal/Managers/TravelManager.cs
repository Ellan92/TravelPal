using System.Collections.Generic;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public static class TravelManager
    {
        public static List<Travel> Travels { get; set; } = new()
        {
            new Travel { Destination = "New York", Country = Enums.Country.USA, Travelers = 4, TravelDays = 14 },
            new Travel { Destination = "Stockholm", Country = Enums.Country.Sweden, Travelers = 2, TravelDays = 3 }

        };



        //public static Travel GetTravels()
        //{
        //    foreach (var travel in Travels)
        //    {
        //        return travel;
        //    }

        //}
    }
}
