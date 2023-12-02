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
using RMS.Frames;

namespace RMS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new SetUp();
        }

        public static void displayLogin() {
            ((MainWindow)Application.Current.MainWindow).Main.Content = new Login();
        }

        public static void displayLogout()
        {
            ((MainWindow)Application.Current.MainWindow).Main.Content = new Login("You have logged out successfully");
        }

        public static void displayManagerPortal()
        {
            ((MainWindow)Application.Current.MainWindow).Main.Content = new ManagerDashboard();
        }

        public static void displayAddItem()
        {
            ((MainWindow)Application.Current.MainWindow).Main.Content = new AddItem();
        }

        public static void displayWaiterPortal()
        {
            ((MainWindow)Application.Current.MainWindow).Main.Content = new WaiterDashboard();
        }

        public static void displayFadingLoader()
        {
            ((MainWindow)Application.Current.MainWindow).Main.Content = new SetUp(true);
        }
    }
}
