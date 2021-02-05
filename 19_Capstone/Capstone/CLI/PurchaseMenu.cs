using System;
using System.Collections.Generic;
using System.Text;
using MenuFramework;
using Capstone.classes;

namespace Capstone.CLI
{

    public class PurchaseMenu : ConsoleMenu
    {
        public VendingMachine randomVendingMachine = new VendingMachine();
        public PurchaseMenu()
        {

            AddOption("Feed Money", randomVendingMachine.CurrentMoneyProvided, "1");
            AddOption("Select Product", randomVendingMachine.CheckIfItemIsAvailable, "2");
            AddOption("Finish Transaction", Close, "3");

            AddOption($"Current Money Provided: {randomVendingMachine.Balance}", Whatever222, "4"); // to make current money provided an option and u click it and it displays the curent money balance

            Configure(cfg =>
            {
                cfg.ItemForegroundColor = ConsoleColor.Cyan;
                cfg.MenuSelectionMode = MenuSelectionMode.KeyString; // KeyString: User types a key, Arrow: User selects with arrow
                cfg.KeyStringTextSeparator = ": ";
                cfg.Title = "Purchase Menu";
            });

            //methods 
            //randomVendingMachine.CurrentMoneyProvided();

            MenuOptionResult Whatever222()
            {

                Console.WriteLine($"Current Money Provided: {randomVendingMachine.Balance}");

                return MenuOptionResult.WaitAfterMenuSelection;
            }


















            //private MenuOptionResult ProductOption()
            //{

            //AddOption("Feed Money", Close, "1");
            //AddOption("Select Product", Close, "2");
            //AddOption("Finish Transaction", Close, "3");

            //Console.WriteLine("What would you like to purchase? (ex: A1, C3, B1) ");
            //string userPurchaseChoice = Console.ReadLine();

            //foreach (KeyValuePair<string, VendingMachineItems> kvp in TotalInventoryList )
            //{

            //}

            //if (TotalInventoryList.ContainsKey(userPurchaseChoice))
            //{

            // }

            //string name = GetString("What is your name? ");
            //Console.WriteLine($"Hello, {name}!");
            //return MenuOptionResult.WaitAfterMenuSelection;
            //}


        }



    }
}
