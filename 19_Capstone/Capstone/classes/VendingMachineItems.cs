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
        
       // public string PurchaseMessage { get; set; } Derived property from slotid get 


        public VendingMachineItems(string name, decimal price, int stockCount, string slotId)//string purchaseMessage)
        {
            Name = Name;
            Price = Price;
            StockCount = stockCount;
            SlotId = slotId;
           // PurchaseMessage = purchaseMessage;


        }

         //public string PrintPurchaseMessage();
        


    }





}
