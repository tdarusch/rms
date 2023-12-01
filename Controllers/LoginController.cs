﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Controllers;
using RMS.EntityObjects;

namespace RMS.Controllers
{
    class LoginController
    {
        public static bool ValidateInput(String username, String password){
            //Usn: Any length, no special characters
            foreach(char c in username) {
                if(!Char.IsLetterOrDigit(c)) {
                    return false;
                }
            }
            bool numericFlag = false;
            bool capitalFlag = false;
            //Passwords: at 6 <= length <= 20 alphanumeric chars, at least 1 digit & 1 capital letter
            foreach(char c in password) {
                if(!Char.IsLetterOrDigit(c)) {
                    return false;
                }
                if(Char.IsDigit(c)) {
                    numericFlag = true;
                }
                if(Char.IsUpper(c)) {
                    capitalFlag = true;
                }
            }
            return numericFlag && capitalFlag;
        }

        public static bool Authenticate(String username, String password) {
            return DBConnector.validateAccount(username, password);
        }

        public static void Login(String username, String password) {
            Account user;
            try {
                user = DBConnector.getUser(username);
            } catch (Exception e) {
                throw new KeyNotFoundException(e.Message);
            }
            if(user.getType().Equals("MANAGER")) {
                MainWindow.displayManagerPortal();
            } else if(user.getType().Equals("WAITER")) {
                MainWindow.displayWaiterPortal();
            } else {
                throw new Exception("Invalid account type found.");
            }
        }
            
    }
}
