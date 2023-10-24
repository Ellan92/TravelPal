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

            // TODO: Läs Country

            // Kolla så att username eller password inte är tomma
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                // Kolla om username redan är taget 
                if (UserManager.RegisterUser(username, password) == null)
                {
                    // Om taget - Messagebox
                    MessageBox.Show("Username already taken!");
                }
                else
                {
                    // Om inte - registrera ny user
                    UserManager.RegisterUser(username, password);

                    // Messagebox - Welcome
                    MessageBox.Show("Welcome to TravelPal, you may now log in");

                    // Öppna MainWindow
                    MainWindow mainWindow = new();
                    mainWindow.Show();

                    //Stäng RegisterWindow
                    Close();
                }
            }
            else
            {
                // Om tomma - Messagebox
                // Även om rutorna är tomma så står det "Username already taken!" Varför?
                MessageBox.Show("You must fill in all fields.");
            }
        }
    }
}
