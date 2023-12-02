using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.EntityObjects;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RMS.Database;
using RMS.Frames;
using System.Security.Cryptography;

namespace RMS.Database
{
    class DBConnector
    {

        public static bool validateAccount(String username, String password) {
            using (DataContext context = new DataContext()){
                return context.Accounts.Any(account => account.Username.Equals(username) && account.Password.Equals(Hash(password)) );
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
                    account = context.Accounts.First(account => account.Username.Equals(username) && account.Password.Equals(Hash(password).ToString()));
                } else {
                    throw new KeyNotFoundException($"Account with username: ${username} not found.");
                }
            }
            return account;
        }

        public static void SaveItem(Item item) {
            using (DataContext context = new DataContext()) {
                context.Items.Add(item);
            }
        }

        public static void SaveOrder(Order order) {
            using (DataContext context = new DataContext()) {
                context.Orders.Add(order);
            }
        }

        public static List<Item> GetItemsByOrderId(int orderId) {
            using (DataContext context = new DataContext()) {
                return context.Orders.Find(orderId).Items;
            }
        }

        public static List<Item> GetAllItems() {
            using (DataContext context = new DataContext()) {
                return context.Items.Where(item => DBNull.Value.Equals(item.OrderId)).ToList();
            }
        }

        public static string Hash(string strData)
        {
            var message = Encoding.UTF8.GetBytes(strData);
            using (var alg = SHA512.Create())
            {
                string hex = "";

                var hashValue = alg.ComputeHash(message);
                foreach (byte x in hashValue)
                {
                    hex += String.Format("{0:x2}", x);
                }
                return hex;
            }
        }
    }
}
