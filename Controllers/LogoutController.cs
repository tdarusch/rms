using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Frames;

namespace RMS.Controllers
{
    class LogoutController
    {
        public static void Logout() {
            Login.DisplayLogout();
        }
    }
}
