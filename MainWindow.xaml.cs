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
using RMS.EntityObjects;
using RMS.Frames;

namespace RMS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new SetUp();
            Application.Current.Properties.Add("currentUser", null);
        }

        public static void displayLogin() {
            ((MainWindow)Application.Current.MainWindow).Main.Content = new Login();
        }

        public static async void displayLogout()
        {
            ((MainWindow)Application.Current.MainWindow).Main.Content = new SetUp();
            await Task.Delay(1500);
            ((MainWindow)Application.Current.MainWindow).Main.Content = new Login("You have logged out successfully");
        }

        public static async void displayManagerPortal(bool loader=false)
        {
            if(loader) {
                ((MainWindow)Application.Current.MainWindow).Main.Content = new SetUp();
                await Task.Delay(1500);
            }
            ((MainWindow)Application.Current.MainWindow).Main.Content = new ManagerDashboard();
        }

        public static void displayAddItem()
        {
            ((MainWindow)Application.Current.MainWindow).Main.Content = new AddItem();
        }

        public static async void displayWaiterPortal()
        {
            ((MainWindow)Application.Current.MainWindow).Main.Content = new SetUp();
            await Task.Delay(2500);
            ((MainWindow)Application.Current.MainWindow).Main.Content = new WaiterDashboard();
        }

    }
}
