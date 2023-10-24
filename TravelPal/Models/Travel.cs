using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Travel
    {
        public string Destination { get; set; }
        public Country Countries { get; set; }
        public int Travelers { get; set; }
        public int TravelDays { get; set; }
        //public Travel(string destination, Country countries, int travelers, int travelDays)
        //{
        //    Destination = destination;
        //    Countries = countries;
        //    Travelers = travelers;
        //    TravelDays = travelDays;
        //}
    }
}
