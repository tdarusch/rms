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
using RMS.Frames.Components;

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
            DisplayMenuItems();
        }

        private void DisplayMenuItems() {
            List<NewMenuItem> list = ItemController.getMenuItemElements();
            foreach (NewMenuItem item in list) {
                MenuItemsBox.Items.Add(item);
            }
        }

        public void LogoutClick(object sender, RoutedEventArgs e)
        {
            LogoutController.Logout();
        }

        public void AddItemClick(object sender, RoutedEventArgs e)
        {
            ItemController.Display();
        }

        public static void Display()
        {
            MainWindow.displayManagerPortal();
        }

        public static void DisplayLoader()
        {
            MainWindow.displayManagerPortal(true);
        }
    }
}
