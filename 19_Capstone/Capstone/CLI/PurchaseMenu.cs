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

        public MenuOptionResult CurrentMoneyProvided()
        {

            while (true)
            {
                decimal moneyEntered = GetDecimal("How much money would you want to add into the machine? ($1, $5, $10, $20)");

                while (moneyEntered == 1 || moneyEntered == 5 || moneyEntered == 10 || moneyEntered == 20)
                {
                    ourVendingMachine.CurrentMoneyProvided(moneyEntered);
                    ourVendingMachine.AuditLog("Feed Money", moneyEntered);
                    return MenuOptionResult.DoNotWaitAfterMenuSelection;
                }
                DollarAmountErrorMessage();

            }
        }

        public MenuOptionResult UserItemChoice()
        {
            //Each slot has a starting stock of 5
            // subtracts however many are bought from the defualt stock
            foreach (KeyValuePair<string, VendingMachineItems> kvp in ourVendingMachine.TotalInventoryList)
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value.ProductType}     Remaining Quantity:{kvp.Value.StockCount} \t {kvp.Value.Name} {kvp.Value.Price} ");// This is where we left off!                   
            }
            string userPurchaseChoice = GetString("What would you like to purchase ? (ex: A1, C3, B1) ");

            ourVendingMachine.UserItemChoice(userPurchaseChoice);
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
            Console.WriteLine($"This is your current balance {ourVendingMachine.Balance}");
        }

        public PurchaseMenu()
        {

            AddOption("Feed Money", CurrentMoneyProvided, "1");
            AddOption("Select Product", UserItemChoice, "2");
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
                Console.WriteLine($"Item Price: {price}");
                Console.WriteLine($"Remaining Balance: ${otherNumber}");

                GumPurchaseMessage();
            }
            else if (type == "Drink")
            {
                Console.WriteLine($"Item Name: {name}");
                Console.WriteLine($"Item Price: {price}");
                Console.WriteLine($"Remaining Balance: ${otherNumber}");

                DrinkPurchaseMessage();
            }
            else if (type == "Candy")
            {
                Console.WriteLine($"Item Name: {name}");
                Console.WriteLine($"Item Price: {price}");
                Console.WriteLine($"Remaining Balance: ${otherNumber}");

                CandyPurchaseMessage();
            }
            else if (type == "Chip")
            {
                Console.WriteLine($"Item Name: {name}");
                Console.WriteLine($"Item Price: {price}");
                Console.WriteLine($"Remaining Balance: ${otherNumber}");

                ChipsPurchaseMessage();
            }                     
        }
    }
}
