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

        //private IUser user;

        public TravelsWindow()
        {
            InitializeComponent();

            lblUsername.Content = UserManager.signedInUser?.Username;
            lblCountry.Content = UserManager.signedInUser?.Country;

            
            List<Travel> allTravels = UserManager.signedInUser.Travels;
            
            


            if (UserManager.signedInUser?.GetType() == typeof(Admin))
            {
                btnAddTravel.IsEnabled = false;
                foreach (var user in UserManager.Users)
                {
                    if (user.Travels != null)
                    {
                        foreach (var travel in user.Travels)
                        {
                            ListViewItem item = new();
                            item.Tag = travel;
                            item.Content = travel.Country;
                            lvTravels.Items.Add(item);

                        }
                    }
                }
            }
            else
            {
                if (allTravels != null)
                {
                    foreach (Travel travel in allTravels.ToList())
                    {
                        ListViewItem item = new();
                        item.Tag = travel;
                        item.Content = travel.Country.ToString();
                        lvTravels.Items.Add(item);
                    }
                }
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

        private void ShowDetails_Click(object sender, RoutedEventArgs e)
        {
            if (lvTravels.SelectedItem != null)
            {
                ListViewItem selectedTravel = (ListViewItem)lvTravels.SelectedItem;

                Travel travel = (Travel)selectedTravel.Tag;

                TravelDetails travelDetails = new(travel);
                travelDetails.Show();
                Close();
            }
            else
            {
                MessageBox.Show("You need to select a travel first!", "Warning");
            }

        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {

            if (lvTravels.SelectedItem == null)
            {
                MessageBox.Show("You need to select a travel first!");
            }
            else
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to remove the selected travel?", "Confirmation", MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    ListViewItem selectedTravel = (ListViewItem)lvTravels.SelectedItem;

                    lvTravels.Items.Remove(selectedTravel);

                    Travel travel = (Travel)selectedTravel.Tag;

                    TravelManager.removeTravel(travel);
                }

            }
        }
    }
}
