using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.EntityObjects;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RMS.Database;
using RMS.Frames;

namespace RMS.Controllers
{
    class DBConnector
    {

        public static bool validateAccount(String username, String password) {
            using (DataContext context = new DataContext()){
                return context.Accounts.Any(account => account.Username.Equals(username) && account.Password.Equals(password.GetHashCode().ToString()) );
            }
        }

        public static async void InitializeDB() {

            DatabaseFacade facade = new DatabaseFacade(new DataContext()); // creates schemas based on DataContext & schemas
            facade.EnsureCreated();
            await Task.Delay(2000);
            MainWindow.displayLogin();

        }

        public static Account GetUser(string username, string password) {
            Account account;
            using (DataContext context = new DataContext()) {
                bool userExists = context.Accounts.Any(account => account.Username.Equals(username));
                if(userExists) {
                    account = context.Accounts.First(account => account.Username.Equals(username) && account.Password.Equals(password.GetHashCode().ToString()));
                } else {
                    throw new KeyNotFoundException($"Account with username: ${username} not found.");
                }
            }
            return account;
        }

        public static void SaveItem(Item item) {
        
        }

        public static void SaveOrder(Order order) {
        
        }

        public static void SaveLogin() {
        
        }
    }
}
