using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS.Frames;
using RMS.EntityObjects;
using RMS.Database;
using RMS.Frames.Components;

namespace RMS.Controllers
{
    class ItemController
    {
        public static void Display() {
            AddItem.Display();
        }

        public static List<NewMenuItem> getMenuItemElements()
        {
            List<NewMenuItem> menuItems = new List<NewMenuItem>();
            List<Item> items = DBConnector.GetAllItems();
            foreach (Item item in items)
            {
                NewMenuItem newMenuItem = new NewMenuItem(item.Name, item.Price, item.Description);
                menuItems.Add(newMenuItem);
            }
            return menuItems;
        }

    }
}
