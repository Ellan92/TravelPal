using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Models
{
    public class Vacation : Travel
    {
        public bool AllInclusive { get; set; }
        public Vacation(string destination, Country country, int travelers, int travelDays, bool allInclusive) : base (destination, country, travelers, travelDays)
        {
            AllInclusive = allInclusive;
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
