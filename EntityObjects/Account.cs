using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using RMS.Database;
using RMS.Controllers;

namespace RMS.EntityObjects
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                string hash = DBConnector.Hash(value);
                password = hash;
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
