using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.classes
{
    public class VendingMachineItems
    {          // Creates instance of a product in the vending machine with these properties
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; } = 5;
        public string SlotId { get; set; }
        public string ProductType { get; set; }
        public string PurchaseMessage          // derived property with a specific message for product type. 
        {
            get
            {
                if (ProductType == "Chip")
                {
                    return "Crunch Crunch, Yum";
                }
                else if (ProductType == "Gum")
                {
                    return "Chew Chew, Yum";

                }
                else if (ProductType == "Candy")
                {
                    return "Munch Munch, Yum";
                }
                else
                {
                    return "Glug Glug, Yum";
                }

            }
        }
           // Constructors 
        public VendingMachineItems(string name, decimal price, int stockCount, string slotId, string productType)
        {
            Name = Name;
            Price = Price;
            StockCount = stockCount;
            SlotId = slotId;
           
            ProductType = ProductType;
        }

        public VendingMachineItems()
        {
        }
    }





}
