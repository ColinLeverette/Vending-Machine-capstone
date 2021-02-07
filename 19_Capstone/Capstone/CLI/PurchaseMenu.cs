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
        public Dictionary<string, VendingMachineItems> TotalInventoryList { get; set; }

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
                    ourVendingMachine.CurrentMoneyProvided(moneyEntered);
                    
                    // blaance and balance + money entered
                    return MenuOptionResult.DoNotWaitAfterMenuSelection;
                }
                DollarAmountErrorMessage();

            }
        }

        public MenuOptionResult UserItemChoiceMenuOption()
        {
            //Each slot has a starting stock of 5
            // subtracts however many are bought from the defualt stock
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
            

           // purchaseMenu.ItemChoiceDisplayMessage(kvp.Value.ProductType, kvp.Value.Name, kvp.Value.Price, Balance);
            // AUDIT LOG ourVendingMachine.AuditLog($"{TotalInventoryList[userPurchaseChoice].Name} {TotalInventoryList[userPurchaseChoice].SlotId}", ourVendingMachine.GetBalance());
            //return MenuOptionResult.WaitAfterMenuSelection;
            return MenuOptionResult.WaitAfterMenuSelection;

            //TODO Maybe put in wrong choice error message that prints out
            //TODO if someone tries purchasing something and they dont have enough money, put a message (TRYING TO STEAL FOOD)

        }

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

        public PurchaseMenu()
        {

            AddOption("Feed Money", FeedMoneyMethod, "1");
            AddOption("Select Product", UserItemChoiceMenuOption, "2");
            AddOption("Finish Transaction", Close, "3");

            //    AddOption($"Current Money Provided: {ourVendingMachine.Balance}", Whatever222, "4"); // to make current money provided an option and u click it and it displays the curent money balance

            Configure(cfg =>
            {
                cfg.ItemForegroundColor = ConsoleColor.Cyan;
                cfg.MenuSelectionMode = MenuSelectionMode.KeyString; // KeyString: User types a key, Arrow: User selects with arrow
                cfg.KeyStringTextSeparator = ": ";
                cfg.Title = "Purchase Menu";
            });
        }

        public void ItemChoiceDisplayMessage(string type, string name, decimal price, decimal otherNumber)
        {
            if (type == "Gum")
            {
                Console.WriteLine($"Item Name: {name}");
                Console.WriteLine($"Item Price: ${price}");
                Console.WriteLine($"Remaining Balance: ${otherNumber}");

                GumPurchaseMessage();

                //
                
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
