using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using TravelPal.Enums;
using TravelPal.Interfaces;
using TravelPal.Managers;
using TravelPal.Models;

namespace TravelPal.Windows
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        List<PackingListItem> allItems = new();
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

            // Kolla om resan är en vacation
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
                // Kolla så alla textrutor och comboboxar inte är tomma
                if (txtCity.Text != "" && !string.IsNullOrWhiteSpace(txtNumberOfTravelers.Text) && !string.IsNullOrWhiteSpace(txtTravelDays.Text) && cbxCountry.SelectedIndex != -1)
                {
                    if (int.TryParse(txtNumberOfTravelers.Text, out int parsedValue) && int.TryParse(txtTravelDays.Text, out int parsedValue2))
                    {
                        // Om inte - spara travel
                        AddVacation(newVacation);
                    }
                    else
                    {
                        MessageBox.Show("Travelers and Travel Days must be a number", "Warning");
                    }

                }
                else
                {
                    // Om tom - MessageBox
                    MessageBox.Show("Some of the fields are empty.", "Warning");
                }
            }
            // Kolla om det är en WorkTrip
            else if (cbxVacationType.SelectedIndex == 1)
            {
                WorkTrip workTrip = new();

                if (txtCity.Text != "" && !string.IsNullOrWhiteSpace(txtNumberOfTravelers.Text) && !string.IsNullOrWhiteSpace(txtTravelDays.Text) && cbxCountry.SelectedIndex != -1)
                {
                    if (int.TryParse(txtNumberOfTravelers.Text, out int parsedValue) && int.TryParse(txtTravelDays.Text, out int parsedValue2))
                    {
                        AddWorkTrip(workTrip);
                    }
                    else
                    {
                        MessageBox.Show("Travelers and Travel Days must be a number", "Warning");
                    }

                }
                else
                {
                    MessageBox.Show("Some of the fields are empty.", "Warning");
                }

            }
        }

        private void AddVacation(Vacation newVacation)
        {
            //OtherItem otherItem = new();
            //otherItem.Name = txtItem.Text;
            //otherItem.Quantity = int.Parse(txtItemQuantity.Text);

            //List<PackingListItem> allItems = new();


            newVacation.Country = (Country)cbxCountry.SelectedItem;
            newVacation.Destination = txtCity.Text;
            newVacation.Travelers = int.Parse(txtNumberOfTravelers.Text);
            newVacation.TravelDays = int.Parse(txtTravelDays.Text);
            newVacation.PackingList = allItems;

            allItems = newVacation.PackingList;

            foreach (PackingListItem item in allItems)
            {
                newVacation.PackingList.Add(item);
            }

            //newVacation.PackingList = lvPackingList.Items;

            //newVacation.PackingList.AddPackingListItem();


            UserManager.signedInUser?.Travels.Add(newVacation);

            MessageBox.Show("Vacation saved!", "Success!");

            TravelsWindow travelsWindow = new();
            travelsWindow.Show();
            Close();
        }

        private void AddWorkTrip(WorkTrip workTrip)
        {
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

        private void AddPackingListItem(PackingListItem item)
        {
            allItems.Add(item);
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

        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (cbTravelDocument.IsChecked == true)
            {
                TravelDocument travelDocument = new();
                //travelDocument.Name = 

            }
            else
            {
                OtherItem otherItem = new();
                otherItem.Name = txtItem.Text;
                otherItem.Quantity = int.Parse(txtItemQuantity.Text);


                ListViewItem item = new();
                item.Tag = otherItem;
                item.Content = otherItem.GetInfo();

                AddPackingListItem(otherItem);
                lvPackingList.Items.Add(item);
                
            }
        }

        private void cbTravelDocument_Checked(object sender, RoutedEventArgs e)
        {
            txtItemQuantity.Visibility = Visibility.Hidden;
            cbRequired.Visibility = Visibility.Visible;
            lblQuantity.Visibility = Visibility.Hidden;
        }
        private void cbTravelDocument_Unchecked(object sender, RoutedEventArgs e)
        {
            txtItemQuantity.Visibility = Visibility.Visible;
            cbRequired.Visibility = Visibility.Hidden;
            lblQuantity.Visibility = Visibility.Visible;
        }
    }
}
