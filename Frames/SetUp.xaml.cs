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

namespace RMS.Frames
{
    /// <summary>
    /// Interaction logic for SetUp.xaml
    /// </summary>
    public partial class SetUp : Page
    {
        public SetUp(bool fadeOut=false)
        {
            InitializeComponent();
            if(fadeOut) {
                FadeOut();
            }
        }

        private async void FadeOut() {
            LoadingAnimation.Opacity = 1;
            while(LoadingAnimation.Opacity >= 0) {
                LoadingAnimation.Opacity -= 0.1;
                await Task.Delay(500);
            }
        }

        public static void IsComplete() {
            MainWindow.displayFadingLoader();
        }
    }
}
