using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMS.EntityObjects
{
    public class Item
    {
        private double price;
        private string name;
        private string description;

        public Item(double price, string name, string description)
        {
            setPrice(price);
            setName(name);
            setDescription(description);
        }

        public double getPrice()
        {
            return price;
        }

        public void setPrice(double price)
        {
            if(price > 0) {
                this.price = price;
            } else {
                throw new ArgumentException("Invalid item price");
            }
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getDescription()
        {
            return description;
        }

        public void setDescription(string description)
        {
            this.description = description;
        }

    }
}
