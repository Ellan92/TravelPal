using System.Collections.Generic;
using TravelPal.Enums;
using TravelPal.Interfaces;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public static class UserManager
    {

        public static List<IUser> Users { get; set; } = new()
        {

            new User("user", "password", Country.USA) {

            Travels = new List<Travel> {

            new Vacation ("New York", Country.USA, 4, 14, true),

            new WorkTrip ("Stockholm", Country.Sweden, 2, 3, "Meeting at 17:30") }
        },
            new Admin("admin", "password", Country.Sweden)
        };
        public static IUser? signedInUser { get; set; }


        public static bool SignInUser(string username, string password)
        {
            foreach (var user in Users)
            {
                if (user.Username == username && user.Password == password)
                // Exception thrown - om man redan registrerat en user och försöker logga in med något username / namn som inte finns får man:
                // System.NullReferenceException: 'Object reference not set to an instance of an object.'
                {
                    signedInUser = user;

                    return true;
                }
            }
            return false;

        }

        public static void SignOutUser()
        {
            signedInUser = null;
        }

        public static IUser? RegisterUser(string username, string password, Country country)
        {
            if (ValidateUsername(username))
            {
                User newUser = new(username, password, country);

                Users.Add(newUser);

                return newUser;
            }

            return null;

        }

        public static bool ValidateUsername(string username)
        {
            bool isValidUsername = true;

            foreach (var user in Users)
            {
                if (user.Username == username)
                {
                    isValidUsername = false;
                }
            }
            return isValidUsername;
        }
        //public static void removeTravel(Travel travel, IUser user)
        //{
        //    user.Travels.Remove(travel);
        //}
        //public static void removeTravel(Travel travel)
        //{
        //    Travels.Remove(travel);
        //}
    }
}
