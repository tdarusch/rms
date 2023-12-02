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
using System.Windows.Navigation;
using System.Windows.Shapes;
using RMS.Controllers;

namespace RMS.Frames
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {

        public Login(string helperText="")
        {
            InitializeComponent();
            setInfo(helperText);
        }

        public void LoginClick(object sender, RoutedEventArgs e){
            String username = usernameInput.Text;
            String password = passwordInput.Text;
            if(LoginController.ValidateInput(username, password)) {
                if(LoginController.Authenticate(username, password)) {
                    LoginController.Login(username, password);
                } else {
                    setError("Incorrect username or password.");
                }
            } else {
                setError("Username must be alphanumeric, Password must be 6-20 characters with a capital letter and number.");
            }
        }

        private void setError(string error) {
            HelperText.Foreground = Brushes.Maroon;
            HelperText.Text = $"Invalid Input: {error}";
            resetInputs();
            resetHelperText();
        }

        private void setInfo(string info) {
            HelperText.Foreground = Brushes.LightGreen;
            HelperText.Text = info;
            resetHelperText();
        }

        private async void resetHelperText() {
            await Task.Delay(5000);
            HelperText.Foreground = Brushes.DarkGray;
            HelperText.Text = "";
        }

        private void resetInputs() {
            usernameInput.Text = "";
            passwordInput.Text = "";
        }

        public static void DisplayLogin() {
            MainWindow.displayLogin();
        }

        public static void DisplayLogout() {
            MainWindow.displayLogout();
        }

    }
}
