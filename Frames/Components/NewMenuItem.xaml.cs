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

namespace RMS.Frames.Components
{
    /// <summary>
    /// Interaction logic for MenuItem.xaml
    /// </summary>
    public partial class NewMenuItem : UserControl
    {
        public NewMenuItem(string name="", double price=0.0, string description="")
        {
            InitializeComponent();
            Name.Text = name;
            Price.Text = price.ToString();
            Description.Text = description;
        }
    }
}
