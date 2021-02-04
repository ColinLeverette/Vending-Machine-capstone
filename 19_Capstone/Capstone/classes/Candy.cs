using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.classes
{
    public class Candy : VendingMachineItems
    {

        public string CandyPurchaseMessage { get; set; }

        public Candy(string name, decimal price, int stockCount, string slotId, string purchaseMessage) : base(name, price, stockCount, slotId, purchaseMessage)
        {

            CandyPurchaseMessage = purchaseMessage;

        }




        public override string PrintPurchaseMessage()
        {
            return CandyPurchaseMessage = "Munch Munch, Yum!";

        }
    }
}