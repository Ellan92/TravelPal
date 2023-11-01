using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Interfaces;

namespace TravelPal.Models
{
    public class Vacation : Travel
    {
        public bool AllInclusive { get; set; }
        public List<PackingListItem> PackingList { get; set; } = new();
        public Vacation(string destination, Country country, int travelers, int travelDays, bool allInclusive, List<PackingListItem> item) : base(destination, country, travelers, travelDays, item)
        {
            AllInclusive = allInclusive;
            PackingList = item;
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
