using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Frames;
using System.Windows;
using RMS.Database;
using RMS.EntityObjects;

namespace RMS.Controllers
{
    class LogoutController
    {
        public static void Logout() {
            Account currentUser = (Account)Application.Current.Properties["currentUser"];
            Application.Current.Properties["currentUser"] = null;
            DBConnector.SaveLogout(currentUser);
            Login.DisplayLogout();
        }
    }
}
