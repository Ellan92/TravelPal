using System.Windows;
using TravelPal.Managers;
using TravelPal.Windows;

namespace TravelPal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            // Läs innehållet i textrutorna (username & password)
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Logga in med UserManager & SignInUser-Metoden

            bool isSuccessfulLogIn = UserManager.SignInUser(username, password);

            // Om inloggningen lyckas - öppna account window

            if (isSuccessfulLogIn)
            {
                TravelsWindow travelswindow = new();
                travelswindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("User does not exist, please try again.");
            }

            // Om inte - MessageBox
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new();
            registerWindow.Show();
            Close();
        }
    }
}
