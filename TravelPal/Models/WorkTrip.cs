using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Interfaces;

namespace TravelPal.Models
{
    public class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }
        public List<PackingListItem> PackingList { get; set; } = new();
        public WorkTrip(string destination, Country country, int travelers, int travelDays, string meetingDetails, List<PackingListItem> item) : base(destination, country, travelers, travelDays, item)
        {
            MeetingDetails = meetingDetails;
            PackingList = item;
        }

        public WorkTrip(string destination, Country country, int travelers, int travelDays, string meetingDetails) : base(destination, country, travelers, travelDays)
        {
            MeetingDetails = meetingDetails;
        }
        public WorkTrip()
        {

        }
        public override string GetInfo()
        {
            return $"{MeetingDetails}";
        }

    }
}
