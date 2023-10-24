using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelPal.Models
{
    public class WorkTrip
    {
        public string MeetingDetails { get; set; }
        public WorkTrip(string meetingDetails)
        {
            MeetingDetails = meetingDetails;
        }

        //GetInfo()
    }
}
