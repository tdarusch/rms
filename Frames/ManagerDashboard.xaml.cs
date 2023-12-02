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
    /// Interaction logic for ManagerDashboard.xaml
    /// </summary>
    public partial class ManagerDashboard : Page
    {
        public ManagerDashboard()
        {
            InitializeComponent();
        }

        public void LogoutClick(object sender, RoutedEventArgs e)
        {
            LogoutController.Logout();
        }

        public void AddItemClick(object sender, RoutedEventArgs e)
        {
            AddItemController.Display();
        }

        public static void Display()
        {
            MainWindow.displayManagerPortal();
        }
    }
}
