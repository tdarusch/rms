using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.EntityObjects
{
    internal class Log
    {
        [Key] 
        public int Id { get; set; }
        private string logEvent;
        public string LogEvent {
            get { return logEvent; }
            set {
                if(value.ToLower().Equals("logout") || value.ToLower().Equals("login")) {
                    logEvent = value.ToUpper();
                } else {
                    logEvent = "N/A";
                }
            }
        }
        public string Time { get; set; }
        public string Date { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }

    }
}
