using System.Collections.Generic;
using System.Windows.Controls;
using TravelPal.Interfaces;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public static class TravelManager
    {
        //public static List<Travel> Travels = new();
        public static void removeTravel(Travel travel)
        {
            User user = (User)UserManager.signedInUser;
            user.Travels.Remove(travel);

            //Travels = user.Travels;
            //Travels.Remove(travel);

        }

        public static void addTravel(Travel travelToAdd, User user)
        {
            //Travels = user.Travels;
            //Travels.Add(travelToAdd);
        }


        //public static void GetTravels(ListView view)
        //{
        //    foreach (IUser user in UserManager.Users)
        //    {
        //        if(user.Username == "admin")
        //        {
        //            continue;
        //        }
        //        foreach (Travel travel in TravelManager.Travels)
        //        {
        //            ListViewItem item = new();
        //            item.Tag = travel;
        //            item.Content = travel.GetInfo();
        //            view.Items.Add(item);
        //        }
        //    }
        //}

        //public static Travel GetTravels()
        //{
        //    foreach (var travel in Travels)
        //    {
        //        return travel;
        //    }

        //}
    }
}
