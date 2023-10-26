using System;
using System.Windows;
using TravelPal.Enums;
using TravelPal.Models;

namespace TravelPal.Windows
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        public AddTravelWindow()
        {
            InitializeComponent();
            LoadCountries();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelWindow = new();
            travelWindow.Show();
            Close();
        }

        private void btnSaveTravel_Click(object sender, RoutedEventArgs e)
        {


            string country = cbCountry.SelectedItem?.ToString();
            string city = txtCity.Text;
            string travelers = txtNumberOfTravelers.Text.ToString();
            string travelDays = txtTravelDays.Text.ToString();

            //newTravel.Country = cbCountry.SelectedItem.ToString();
            //newTravel.Destination = txtCity.Text;

        }
        public void LoadCountries()
        {
            foreach (Country country in Enum.GetValues(typeof(Country)))
            {
                cbCountry.Items.Add(country);
            }
        }
    }
}
