using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RMS.EntityObjects
{
    public class Account
    {
        [Key]
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                id = value.GetHashCode();
            }
        }
        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = value.GetHashCode().ToString();
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value.GetHashCode().ToString();
            }
        }
        private string type;
        public string Type
        {
            get { return type; }
            set
            {
                if (value.ToLower().Equals("manager"))
                {
                    type = "MANAGER";
                }
                else
                {
                    // invalid data would break db on setup without a proper value - if an
                    // invalid type is given on setup then we just make them a waiter
                    // since in our case it makes sense b/c they would have lower privs
                    type = "WAITER";
                }
            }
        }
    }
}
