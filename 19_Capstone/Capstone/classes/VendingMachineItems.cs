using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.classes
{
    public class VendingMachineItems
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockCount { get; set; } = 5;
        public string SlotId { get; set; }
        public string ProductType { get; set; }
        public string PurchaseMessage          // derived
        {
            get
            {
                if (ProductType == "Chips")
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

        // public string PurchaseMessage { get; set; } Derived property from slotid get 


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

        //public string PrintPurchaseMessage();



    }





}
