using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Models
{
    public class Vacation : Travel
    {
        public bool AllInclusive { get; set; }
        //public Vacation(bool allInclusive)
        //{
        //    AllInclusive = allInclusive;
        //}
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
