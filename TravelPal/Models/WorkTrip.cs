using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Models
{
    public class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }

        public WorkTrip(string destination, Country country, int travelers, int travelDays, string meetingDetails) : base(destination, country, travelers, travelDays)
        {
            MeetingDetails = meetingDetails;
        }

        public override string GetInfo()
        {
            return $"{MeetingDetails}";
        }

        //GetInfo()
    }
}
