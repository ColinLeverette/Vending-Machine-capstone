using System;
using System.Collections.Generic;
using System.Text;
using MenuFramework;
using Capstone.classes;

namespace Capstone.CLI
{
    public class PurchaseMenu : ConsoleMenu
    {
        public VendingMachine ourVendingMachine { get; set; }
        public Dictionary<string, VendingMachineItems> TotalInventoryList { get; set; }  // Dictionary to hold items in vending machine

        // Takes user's money in specific dollar amounts only
        public MenuOptionResult FeedMoneyMethod()
        {
            while (true)
            {
                decimal moneyEntered = GetDecimal("How much money would you want to add into the machine? ($1, $5, $10, $20)", 0);
                if (moneyEntered == 0)
                {
                    return MenuOptionResult.DoNotWaitAfterMenuSelection;
                }
                
                if (moneyEntered == 1 || moneyEntered == 5 || moneyEntered == 10 || moneyEntered == 20)
                {
                    
                    ourVendingMachine.AuditLogFeedMoney("FEED MONEY:", ourVendingMachine.Balance, ourVendingMachine.RunningBalanceMethod(moneyEntered));
                    ourVendingMachine.AddMoney(moneyEntered);
                    
                    // blaance and balance + money entered
                    return MenuOptionResult.DoNotWaitAfterMenuSelection;
                }
                DollarAmountErrorMessage();
            }
        }

        // Asks user what they'd like to choose based on SlotID,  displays error messages based on stock amount and if there's enough funds
        public MenuOptionResult UserItemChoiceMenuOption()
        {
            foreach (KeyValuePair<string, VendingMachineItems> kvp in ourVendingMachine.TotalInventoryDictionary)
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value.ProductType}     Quantity Remaining:   {kvp.Value.StockCount} \t {kvp.Value.Name} ${kvp.Value.Price} ");                
            }
            string userPurchaseChoice = GetString("What would you like to purchase ? (ex: A1, C3, B1) ");

            VendingMachineItems product;
            try
            {
                product = ourVendingMachine.UserItemChoice(userPurchaseChoice);
                
                Console.WriteLine($"Enjoy your {product.Name}. {product.SlotId}. {product.Price:C}");
                Console.WriteLine(product.PurchaseMessage);
            } 
            catch (Exception e)
            {
                if (e.Message == VendingMachine.INSUFFICIENT_FUNDS_MESSAGE)
                {
                    this.InsufficientFundsMessage();
                }
                else if (e.Message == VendingMachine.INVALID_SLOT_MESSAGE)
                {
                    this.WrongSlotIdEnteredError();
                }
                else if (e.Message == VendingMachine.OUT_OF_STOCK_MESSAGE)
                {
                    this.NotEnoughStock();
                }
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        // Messages based on product type
        public void GumPurchaseMessage()
        {
            Console.WriteLine("Chew Chew, Yum");
        }

        public void CandyPurchaseMessage()
        {
            Console.WriteLine("Munch Munch, Yum");
        }

        public void DrinkPurchaseMessage()
        {
            Console.WriteLine("Glug Glug, Yum");
        }
        public void ChipsPurchaseMessage()
        {
            Console.WriteLine("Crunch Crunch, Yum");
        }
        // Error messages based on stock amount, incorrect slotID, insufficient Funds, invalid dollar amount
        public void NotEnoughStock()
        {
            Console.WriteLine("Error: Sold out!");
        }

        public void WrongSlotIdEnteredError()
        {
            Console.WriteLine("Error: Unknown slotID entered, you will be returned to the purchase menu");
        }
        public void DollarAmountErrorMessage()
        {
            Console.WriteLine("Please enter a valid dollar amount ($1, $5, $10, $20)");
        }

        public void InsufficientFundsMessage()
        {
            Console.WriteLine("Please feed more money.");
        }

        protected override void OnAfterShow()
        {
            Console.WriteLine($"This is your current balance ${ourVendingMachine.Balance}");
        }
        
        // Displays second menu after user selects "purchase menu"
        public PurchaseMenu()
        {
            AddOption("Feed Money", FeedMoneyMethod, "1");
            AddOption("Select Product", UserItemChoiceMenuOption, "2");
            AddOption("Finish Transaction", Close, "3");

            Configure(cfg =>
            {
                cfg.ItemForegroundColor = ConsoleColor.Yellow;
                cfg.MenuSelectionMode = MenuSelectionMode.KeyString; // KeyString: User types a key, Arrow: User selects with arrow
                cfg.KeyStringTextSeparator = ": ";
                cfg.Title = "Purchase Menu";
            });
        }
        // Displays item details and message based on product type selection
        public void ItemChoiceDisplayMessage(string type, string name, decimal price, decimal otherNumber)
        {
            if (type == "Gum")
            {
                Console.WriteLine($"Item Name: {name}");
                Console.WriteLine($"Item Price: ${price}");
                Console.WriteLine($"Remaining Balance: ${otherNumber}");

                GumPurchaseMessage();
            }
            else if (type == "Drink")
            {
                Console.WriteLine($"Item Name: {name}");
                Console.WriteLine($"Item Price: ${price}");
                Console.WriteLine($"Remaining Balance: ${otherNumber}");

                DrinkPurchaseMessage();
            }
            else if (type == "Candy")
            {
                Console.WriteLine($"Item Name: {name}");
                Console.WriteLine($"Item Price: ${price}");
                Console.WriteLine($"Remaining Balance: ${otherNumber}");

                CandyPurchaseMessage();
            }
            else if (type == "Chip")
            {
                Console.WriteLine($"Item Name: {name}");
                Console.WriteLine($"Item Price: ${price}");
                Console.WriteLine($"Remaining Balance: ${otherNumber}");

                ChipsPurchaseMessage();
            }                     
        }
    }
}
