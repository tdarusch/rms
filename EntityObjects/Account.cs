using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace RMS.EntityObjects
{
    public class Account
    {
        private int accountId;
        private string username;
        private string password;
        private string type;

        public Account(int accountId, string username, string password, string type)
        {
            setAccountId(accountId);
            setUsername(username);
            setPassword(password);
            setType(type);
        }

        public int getAccountId()
        {
            return accountId;
        }

        public void setAccountId(int accountId)
        {
            if(accountId > 0) {
                this.accountId = accountId;
            } else {
                throw new ArgumentException("Invalid account id");
            }
        }

        public string getUsername()
        {
            return username;
        }

        public void setUsername(string username)
        {
            this.username = username;
        }

        public string getPassword()
        {
            return password;
        }

        public void setPassword(string password)
        {
            String hashPassword = getHashString(password);
            this.password = hashPassword;
        }

        public string getType()
        {
            return type;
        }

        public void setType(string type)
        {
            if (type.ToLower().Equals("waiter")) {
                this.type = "WAITER";
            } else if (type.ToLower().Equals("manager")) {
                this.type = "MANAGER";
            }
            else {
                throw new ArgumentException("Invalid account type");
            }
        }

        public static string getHashString(string input)
        {
            if (String.IsNullOrEmpty(input))
                return String.Empty;

            using (var sha = new SHA256Managed())
            {
                byte[] textData = System.Text.Encoding.UTF8.GetBytes(input);
                byte[] hash = sha.ComputeHash(textData);
                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }

    }
}
