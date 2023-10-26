using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Models
{
    public class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }

        //public WorkTrip(string meetingDetails)
        //{
        //    MeetingDetails = meetingDetails;
        //}

        public override string GetInfo()
        {
            return $"{MeetingDetails}";
        }

        //GetInfo()
    }
}
