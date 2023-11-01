using System;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Enums;
using TravelPal.Managers;
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

            cbxVacationType.Items.Add("Vacation");
            cbxVacationType.Items.Add("Work trip");

        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelWindow = new();
            travelWindow.Show();
            Close();
        }

        private void btnSaveTravel_Click(object sender, RoutedEventArgs e)
        {


            if (cbxVacationType.SelectedIndex == 0)
            {

                Vacation newVacation = new();

                if (cbAllInclusive.IsChecked == true)
                {
                    newVacation.AllInclusive = true;
                }
                else
                {
                    newVacation.AllInclusive = false;
                }

                newVacation.Country = (Country)cbxCountry.SelectedItem;
                newVacation.Destination = txtCity.Text;
                newVacation.Travelers = int.Parse(txtNumberOfTravelers.Text);
                newVacation.TravelDays = int.Parse(txtTravelDays.Text);

                UserManager.signedInUser?.Travels.Add(newVacation);

                MessageBox.Show("Vacation saved!", "Success!");

                TravelsWindow travelsWindow = new();
                travelsWindow.Show();
                Close();
            }
            else if (cbxVacationType.SelectedIndex == 1)
            {
                WorkTrip workTrip = new();

                workTrip.Country = (Country)cbxCountry.SelectedItem;
                workTrip.Destination = txtCity.Text;
                workTrip.Travelers = int.Parse(txtNumberOfTravelers.Text);
                workTrip.TravelDays = int.Parse(txtTravelDays.Text);
                workTrip.MeetingDetails = txtMeetingDetails.Text;

                //TODO: Om Travelers eller TravelDays inte är siffra så crashar programmet

                UserManager.signedInUser?.Travels.Add(workTrip);

                MessageBox.Show("Work trip saved!", "Success!");

                TravelsWindow travelsWindow = new();
                travelsWindow.Show();
                Close();
            }


        }
        public void LoadCountries()
        {
            foreach (Country country in Enum.GetValues(typeof(Country)))
            {
                cbxCountry.Items.Add(country);
            }
        }

        private void cbxVacationType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxVacationType.SelectedIndex == 0)
            {
                txtMeetingDetails.Visibility = Visibility.Hidden;
                lblMeetingDetails.Visibility = Visibility.Hidden;

                cbAllInclusive.Visibility = Visibility.Visible;
            }
            else
            {
                txtMeetingDetails.Visibility = Visibility.Visible;
                lblMeetingDetails.Visibility = Visibility.Visible;

                cbAllInclusive.Visibility = Visibility.Hidden;
            }
        }
    }
}
