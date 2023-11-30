using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.password = password;
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
    }
}
