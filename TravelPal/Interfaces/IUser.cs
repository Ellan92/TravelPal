using System.Collections.Generic;
using System.Windows.Documents;
using TravelPal.Enums;
using TravelPal.Models;

namespace TravelPal.Interfaces
{
    public interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Country Country { get; set; }
        public List<Travel> Travels { get; set; }
    }
}
