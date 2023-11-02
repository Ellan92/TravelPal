using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Interfaces;

namespace TravelPal.Models
{
    public class Vacation : Travel
    {
        public bool AllInclusive { get; set; }
        public Vacation(string destination, Country country, int travelers, int travelDays, bool allInclusive, List<PackingListItem> items) : base(destination, country, travelers, travelDays, items)
        {
            AllInclusive = allInclusive;

        }

        public Vacation(string destination, Country country, int travelers, int travelDays, bool allInclusive) : base(destination, country, travelers, travelDays)
        {
            AllInclusive = allInclusive;
        }
        public Vacation()
        {

        }
        public override string GetInfo()
        {
            if (AllInclusive == true)
            {
                return $"Yes";
            }
            return $"No";

        }
    }
}
