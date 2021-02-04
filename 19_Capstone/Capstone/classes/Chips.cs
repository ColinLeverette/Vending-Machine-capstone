using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.classes
{
    public class Chips : VendingMachineItems
    {

        public string ChipsPurchaseMessage { get; set; }

        public Chips(string name, decimal price, int stockCount, string slotId, string purchaseMessage) : base(name, price, stockCount, slotId, purchaseMessage)
        {

            ChipsPurchaseMessage = purchaseMessage;

        }




        public override string PrintPurchaseMessage()
        {
            return ChipsPurchaseMessage = "Crunch Crunch, Yum!";

        }
    }
}