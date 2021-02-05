using System;
using System.Collections.Generic;
using System.Text;
using MenuFramework;
using Capstone.classes;

namespace Capstone.CLI
{

    public class PurchaseMenu : ConsoleMenu 
    {
        public VendingMachine ourVendingMachine { get;  set; }
        public Dictionary<string, VendingMachineItems> TotalInventoryList { get; set; }

        public MenuOptionResult CurrentMoneyProvided()
        {

            while (true)
            {
                decimal moneyEntered = GetDecimal("How much money would you want to add into the machine? ($1, $5, $10, $20)");

                while (moneyEntered == 1 || moneyEntered == 5 || moneyEntered == 10 || moneyEntered == 20)
                {
                    ourVendingMachine.CurrentMoneyProvided(moneyEntered);
                    return MenuOptionResult.DoNotWaitAfterMenuSelection;
                }
                DollarAmountErrorMessage();
            }
        }

        public MenuOptionResult UserItemChoice()
        {
            //Each slot has a starting stock of 5
            // subtracts however many are bought from the defualt stock
            
            string userPurchaseChoice = GetString("What would you like to purchase ? (ex: A1, C3, B1) ");

            ourVendingMachine.UserItemChoice(userPurchaseChoice);
            
            return MenuOptionResult.DoNotWaitAfterMenuSelection;

            //TODO Maybe put in wrong choice error message that prints out
            //TODO if someone tries purchasing something and they dont have enough money, put a message (TRYING TO STEAL FOOD)

        }

        public void DollarAmountErrorMessage()
        {
            Console.WriteLine("Please enter a valid dollar amount ($1, $5, $10, $20)");
        }

        protected override void OnAfterShow()
        {
            Console.WriteLine($"This is your current balance {ourVendingMachine.Balance}");
        }
        //public VendingMachine randomVendingMachine = new VendingMachine();
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
       

            //MenuOptionResult Whatever222()
            //{

            //    Console.WriteLine($"Current Money Provided: {ourVendingMachine.Balance}");

            //    return MenuOptionResult.WaitAfterMenuSelection;
            //}
            

        }

       
    }
}
