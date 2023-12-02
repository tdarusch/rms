using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.EntityObjects
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public List<Item> Items { get; set; }
        public Account Waiter { get; set; }
        private int tableNo;
        public int TableNo
        {
            get { return tableNo; }
            set 
            {
                if(value >= 0) {
                    tableNo = value;
                } else {
                    tableNo = -1;
                }
            }
        }
    }
}
