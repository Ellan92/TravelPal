using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using TravelPal.Interfaces;
using TravelPal.Managers;
using TravelPal.Models;

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
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            // Läst textrutorna username & password

            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                if (UserManager.RegisterUser(username, password) == null)
                {
                    MessageBox.Show("Username already taken!");
                }
                else
                {
                    UserManager.RegisterUser(username, password);

                    MessageBox.Show("Welcome to TravelPal, you may now log in");

                    MainWindow mainWindow = new();
                    mainWindow.Show();
                    Close();
                }
            }
            else
            {
                MessageBox.Show("You must fill in all fields.");
            }

            // TODO: Läs Country

            // Kolla om username redan är taget



            // Om inte - lägg till användare

            // Om taget - MessageBox
        }
    }
}
