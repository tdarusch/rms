﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMS.EntityObjects
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        private double price;
        public double Price
        {
            get { return price; }
            set {
                if (value > 0.0) {
                    price = value;
                } else {
                    price = 0.0;
                }
            }
        }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("Account")]
        public int OrderId { get; set; }

    }
}
