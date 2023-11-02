using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Interfaces;

namespace TravelPal.Models
{
    public class Travel
    {
        public string Destination { get; set; }
        public Country Country { get; set; }
        public int Travelers { get; set; }
        public int TravelDays { get; set; }
        public List<PackingListItem> PackingList { get; set; }

        public Travel(string destination, Country country, int travelers, int traveldays, List<PackingListItem> items)
        {
            Destination = destination;
            Country = country;
            Travelers = travelers;
            TravelDays = traveldays;
            PackingList = items;
        }

        public Travel(string destination, Country country, int travelers, int traveldays)
        {
            Destination = destination;
            Country = country;
            Travelers = travelers;
            TravelDays = traveldays;
        }

        public Travel()
        {

        }

        public virtual string GetInfo()
        {
            return $"{Country}";
        }

        //public Travel(string destination, Country countries, int travelers, int travelDays)
        //{
        //    Destination = destination;
        //    Countries = countries;
        //    Travelers = travelers;
        //    TravelDays = travelDays;
        //}
    }
}
