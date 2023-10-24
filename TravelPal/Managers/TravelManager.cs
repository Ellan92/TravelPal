using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public class TravelManager
    {
        List<Travel> travels = new()
        {
            new Travel { Destination = "New York", Countries = Enums.Country.USA, Travelers = 4, TravelDays = 14 }
        };

    }
}
