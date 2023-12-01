using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.EntityObjects;

namespace RMS.Controllers
{
    class DBConnector
    {

        public static bool validateAccount(String username, String password) {
            Account user;
            try {
                user = getUser(username);
            } catch (Exception) {
                return false;
            }
            if(user.getPassword().Equals(Account.getHashString(password))) {
                return true;
            }
            return false;
        }

        private static List<Account> getAccounts() {
            //This method will fetch accounts from the db, probably needs to be async. everything here now is dummy code for testing
            List<Account> accounts = new List<Account>();
            Account testManager = new Account(1, "manager", "Password1", "manager");
            Account testWaiter = new Account(2, "waiter", "Password1", "waiter");
            accounts.Add(testManager);
            accounts.Add(testWaiter);
            return accounts;
        }

        public static Account getUser(String username) {
            List<Account> accounts = getAccounts();
            foreach (Account account in accounts)
            {
                if (account.getUsername().Equals(username)) {
                    return account;
                }
            }
            throw new KeyNotFoundException($"User with username: {username} not found.");
        }
    }
}
