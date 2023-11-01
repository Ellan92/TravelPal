using System;
using System.Windows;
using TravelPal.Enums;
using TravelPal.Managers;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            LoadCountries();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            // Läst textrutorna username & password
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Kolla så att username, password och country inte är tomma
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password) && cbCountry.SelectedIndex != -1)
            {
                Country country = (Country)cbCountry.SelectedItem;

                // Kolla om username redan är taget 
                if (UserManager.RegisterUser(username, password, country) == null)
                {
                    // Om taget - Messagebox
                    MessageBox.Show("Username already taken!", "Warning");
                }
                else
                {
                    // Om inte - registrera ny user
                    UserManager.RegisterUser(username, password, country);

                    // Messagebox - Welcome
                    MessageBox.Show("Welcome to TravelPal, you may now log in.");

                    // Öppna MainWindow
                    // TODO: Skicka med user

                    MainWindow mainWindow = new();
                    mainWindow.Show();

                    //Stäng RegisterWindow
                    Close();
                }
            }
            else
            {
                // Om tomma - Messagebox
                MessageBox.Show("You must fill in all fields.", "Warning");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
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
