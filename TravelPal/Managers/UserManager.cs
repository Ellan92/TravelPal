using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TravelPal.Interfaces;
using TravelPal.Models;

namespace TravelPal.Managers
{
    public class UserManager
    {

        public static List<IUser> Users { get; set; } = new()
        {
            new User ("user", "password")
        };
        public static IUser? signedInUser { get; set; }

        public static bool SignInUser(string username, string password)
        {
            foreach (var user in Users)
            {
                if(user.Username == username && user.Password == password)
                // Exception thrown - om man redan registrerat en user och försöker logga in med något username / namn som inte finns får man:
                // System.NullReferenceException: 'Object reference not set to an instance of an object.'
                {
                    signedInUser = user;

                    return true;
                }
            }
            return false;
            
        }

        public static IUser? RegisterUser(string username, string password)
        {
            if (ValidateUsername(username))
            {
                User newUser = new(username, password);

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
    }
}
