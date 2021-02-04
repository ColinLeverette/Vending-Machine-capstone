using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.classes
{
    public class Beverages : VendingMachineItems
    {

        public string BeveragePurchaseMessage { get; set; }

        public Beverages(string name, decimal price, int stockCount, string slotId, string purchaseMessage) : base (name, price, stockCount, slotId, purchaseMessage)
        {

            BeveragePurchaseMessage = purchaseMessage;

        }




        public override string PrintPurchaseMessage()
        {
         return   BeveragePurchaseMessage = "Glug Glug, Yum!";
            
        }



    }
}
