using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
        public List<PackingListItem> allItems = new();

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
                if (txtCity.Text == "")
                {
                    MessageBox.Show("Destination can't be empty");
                }
                else if (!Regex.IsMatch(txtCity.Text, @"^[a-öA-Ö]+$"))
                {
                    MessageBox.Show("Destination can't be a number");
                }

                // Kolla så alla textrutor och comboboxar inte är tomma
                else if (!string.IsNullOrWhiteSpace(txtNumberOfTravelers.Text) && !string.IsNullOrWhiteSpace(txtTravelDays.Text) && cbxCountry.SelectedIndex != -1 && cbxVacationType.SelectedIndex != -1)
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
            List<PackingListItem> allItems = new();

            foreach (ListViewItem item in lvPackingList.Items)
            {
                PackingListItem packingItem = (PackingListItem)item.Tag;
                allItems.Add(packingItem);
            }

            newVacation.Country = (Country)cbxCountry.SelectedItem;
            newVacation.Destination = txtCity.Text;
            newVacation.Travelers = int.Parse(txtNumberOfTravelers.Text);
            newVacation.TravelDays = int.Parse(txtTravelDays.Text);
            newVacation.PackingList = allItems;


            //foreach (ListViewItem item in allPackingItems)
            //{
            //    newVacation.PackingList.Add((PackingListItem)item.Tag);
            //}




            UserManager.signedInUser?.Travels.Add(newVacation);

            MessageBox.Show("Vacation saved!", "Success!");

            TravelsWindow travelsWindow = new();
            travelsWindow.Show();
            Close();
        }

        private void AddWorkTrip(WorkTrip workTrip)
        {
            List<PackingListItem> allItems = new();

            foreach (ListViewItem item in lvPackingList.Items)
            {
                PackingListItem packingItem = (PackingListItem)item.Tag;
                allItems.Add(packingItem);
            }

            workTrip.Country = (Country)cbxCountry.SelectedItem;
            workTrip.Destination = txtCity.Text;
            workTrip.Travelers = int.Parse(txtNumberOfTravelers.Text);
            workTrip.TravelDays = int.Parse(txtTravelDays.Text);
            workTrip.MeetingDetails = txtMeetingDetails.Text;
            workTrip.PackingList = allItems;

            //TODO: Om Travelers eller TravelDays inte är siffra så crashar programmet

            UserManager.signedInUser?.Travels.Add(workTrip);

            MessageBox.Show("Work trip saved!", "Success!");

            TravelsWindow travelsWindow = new();
            travelsWindow.Show();
            Close();
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
                travelDocument.Name = txtItem.Text;

                if (cbRequired.IsChecked == true)
                {
                    travelDocument.Required = true;
                }
                else
                {
                    travelDocument.Required = false;
                }

                ListViewItem item = new();
                item.Tag = travelDocument;
                item.Content = travelDocument.GetInfo();

                lvPackingList.Items.Add(item);

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

        private void cbxCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            for (int i = 0; i < lvPackingList.Items.Count; i++)
            {
                ListViewItem item = new();
                item = (ListViewItem)lvPackingList.Items[i];
                if (item.ToString().Contains("Passport") || item.ToString().Contains("passport"))
                {
                    lvPackingList.Items.RemoveAt(i);
                }
            }

            Country userCountry = UserManager.signedInUser.Country;
            Country destinationCountry = (Country)cbxCountry.SelectedItem;

            if (userCountry == destinationCountry)
            {
                TravelDocument passport = new();
                passport.Name = "Passport";
                passport.Required = false;

                ListViewItem item = new();
                item.Tag = passport;
                item.Content = passport.GetInfo();

                lvPackingList.Items.Add(item);
                return;
            }

            bool isEuropeanCountry = false;
            bool isEuropeanUser = false;

            if (cbxCountry.SelectedIndex != -1)
            {
                // Kollar om vi bor i EU
                foreach (EuropeanCountry europeanCountry in Enum.GetValues(typeof(EuropeanCountry)))
                {
                    if (UserManager.signedInUser?.Country.ToString() == europeanCountry.ToString())
                    {
                        isEuropeanUser = true;
                    }

                }


                foreach (EuropeanCountry europeanCountry in Enum.GetValues(typeof(EuropeanCountry)))
                {
                    if (cbxCountry.SelectedItem.ToString() == europeanCountry.ToString())
                    {
                        isEuropeanCountry = true;
                    }
                }




                if (isEuropeanCountry && isEuropeanUser)
                {
                    TravelDocument passport = new();
                    passport.Name = "Passport";
                    passport.Required = false;

                    ListViewItem item = new();
                    item.Tag = passport;
                    item.Content = passport.GetInfo();

                    lvPackingList.Items.Add(item);
                }
                //else if(!isEuropeanUser && isEuropeanCountry)
                //{
                //    TravelDocument passport = new();
                //    passport.Name = "Passport";
                //    passport.Required = true;

                //    ListViewItem item = new();
                //    item.Tag = passport;
                //    item.Content = passport.GetInfo();

                //    lvPackingList.Items.Add(item);
                //}
                else if (!isEuropeanCountry && isEuropeanUser)
                {
                    TravelDocument passport = new();
                    passport.Name = "Passport";
                    passport.Required = true;

                    ListViewItem item = new();
                    item.Tag = passport;
                    item.Content = passport.GetInfo();

                    lvPackingList.Items.Add(item);
                }
                else if (!isEuropeanCountry || !isEuropeanUser)
                {
                    TravelDocument passport = new();
                    passport.Name = "Passport";
                    passport.Required = true;

                    ListViewItem item = new();
                    item.Tag = passport;
                    item.Content = passport.GetInfo();

                    lvPackingList.Items.Add(item);
                }
            }





            //if (UserManager.signedInUser?.Country.GetType() == typeof(Country))
            //{
            //    TravelDocument passport = new();
            //    passport.Name = "Passport";
            //    passport.Required = true;

            //    ListViewItem item = new();
            //    item.Tag = passport;
            //    item.Content = passport.GetInfo();

            //    lvPackingList.Items.Add(item);
            //}
        }
    }
}
