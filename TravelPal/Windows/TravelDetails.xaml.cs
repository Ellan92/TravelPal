using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TravelPal.Enums;
using TravelPal.Models;

namespace TravelPal.Windows
{
    /// <summary>
    /// Interaction logic for TravelDetails.xaml
    /// </summary>
    public partial class TravelDetails : Window
    {
        public TravelDetails(Travel travel)
        {


            InitializeComponent();
            txtCountry.Text = travel.Country.ToString();
            txtCity.Text = travel.Destination.ToString();
            txtTravelers.Text = travel.Travelers.ToString();

            if(travel.GetType() == typeof(WorkTrip))
            {
                txtTravelType.Text = "Work Trip";
                WorkTrip workTrip = (WorkTrip)travel;
                txtMeetingDetails.Text = workTrip.GetInfo();

                lblMeetingDetails.Visibility = Visibility.Visible;
                txtMeetingDetails.Visibility = Visibility.Visible;

                lblAllInclusive.Visibility = Visibility.Hidden;
                txtAllInclusive.Visibility = Visibility.Hidden;
                
            }
            else
            {

                txtTravelType.Text = "Vacation";
                Vacation vacation = (Vacation)travel;
                txtAllInclusive.Text = vacation.GetInfo();

                lblAllInclusive.Visibility = Visibility.Visible;
                txtAllInclusive.Visibility = Visibility.Visible;

                lblMeetingDetails.Visibility = Visibility.Hidden;
                txtMeetingDetails.Visibility = Visibility.Hidden;
            }

            
            
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new();
            travelsWindow.Show();
            Close();
        }
    }
}
