using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Interfaces;

namespace TravelPal.Managers
{
    public class UserManager
    {
        List<IUser> users = new();
        public IUser signedInUser { get; set; }
    }
}
