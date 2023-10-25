using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Interfaces;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal.Windows
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {
        public TravelsWindow()
        {
            InitializeComponent();
            List<IUser> users = UserManager.Users;


            lblUsername.Content = UserManager.signedInUser?.Username;
            lblCountry.Content = UserManager.signedInUser?.Country;

            List<Travel> allTravels = TravelManager.Travels;

            foreach (Travel travel in allTravels.ToList())
            {
                ListViewItem item = new();
                item.Tag = travel;
                item.Content = travel.GetInfo();

                lvTravels.Items.Add(item);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UserManager.SignOutUser();
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();

        }

        private void AddTravel_Click(object sender, RoutedEventArgs e)
        {
            AddTravelWindow addTravelWindow = new();
            addTravelWindow.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            InfoWindow infoWindow = new();
            infoWindow.Show();
            Close();
        }
    }
}
