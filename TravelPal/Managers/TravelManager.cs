using TravelPal.Interfaces;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public static class TravelManager
    {
        
        public static void removeTravel(Travel travel)
        {
            if (UserManager.signedInUser.GetType() == typeof(User))
            {
                User user = (User)UserManager.signedInUser;
                user.Travels.Remove(travel);
            }
            else
            {
                foreach (IUser user in UserManager.Users)
                {
                    if (user.GetType() == typeof(User))
                    {
                        User selectedUser = (User)user;
                        selectedUser.Travels.Remove(travel);
                    }
                }

            }
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
