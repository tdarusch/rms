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
using RMS.Database;

namespace RMS.Frames
{
    /// <summary>,
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Page
    {
        public AddItem()
        {
            InitializeComponent();
        }

        public static void Display()
        {
            MainWindow.displayAddItem();
        }

        public void Submit(object sender, RoutedEventArgs e)
        {

            bool validItem = true;
            
            string name = ItemName.Text;
            foreach (char c in name) {
                if (!Char.IsLetter(c) && !Char.IsWhiteSpace(c)) {
                    setError("Item name cannot contain numbers/special characters");
                    ItemName.Text = "";
                    validItem = false;
                    break;
                }
            }

            string description = ItemDescription.Text;
            if (description.Length > 400) {
                setError("Item description cannot exceed 400 characters");
                ItemDescription.Text = "";
                validItem = false;
            }

            double price;
            bool isValidPrice = Double.TryParse(ItemPrice.Text, out price);
            if(!isValidPrice) {
                setError("Price must be a valid integer");
                ItemPrice.Text = "";
                validItem = false;
            }
            if(validItem) {
                Item newItem = new Item();
                newItem.Name = name;
                newItem.Description = description;
                newItem.Price = price;
                DBConnector.SaveItem(newItem);
                ManagerDashboard.Display();
            }
        }

        private void setError(string error)
        {
            HelperText.Foreground = Brushes.Maroon;
            HelperText.Text = $"Invalid Input: {error}";
            resetHelperText();
        }

        private async void resetHelperText()
        {
            await Task.Delay(3500);
            HelperText.Foreground = Brushes.DarkGray;
            HelperText.Text = "";
        }

    }
}
