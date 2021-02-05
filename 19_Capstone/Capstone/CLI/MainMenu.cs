using Capstone.classes;
using MenuFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.CLI
{
    public class MainMenu : ConsoleMenu
    {
        public VendingMachine ourVendingMachine = new VendingMachine();

        /*******************************************************************************
         * Private data:
         * Usually, a menu has to hold a reference to some type of "business objects",
         * on which all of the actions requested by the user are performed. A common 
         * technique would be to declare those private fields here, and then pass them
         * in through the constructor of the menu.
         * ****************************************************************************/

        // NOTE: This constructor could be changed to accept arguments needed by the menu

        //TODO Show the list of products available and allows the customer to enter a code 
        //TODO If the product does not exist, the customer is inofmred and return to the purchase menu
        //TODO if the product is sold out, the customer is informed nad returned to the Purchase menu
        //TODO Dispensing an item prints the name, cost, and the money remaining. Also print the message.
        //TODO Add audit log 

        public MainMenu()
        {
            // Add Sample menu options
            AddOption("(1): Display Vending Machine items", DisplayItems, "1");
            AddOption(" (2): Purchase", ExitStatement, "2");
            AddOption("(3): Exit", Close, "3");

            Configure(cfg =>
           {
               cfg.ItemForegroundColor = ConsoleColor.Cyan;
               cfg.MenuSelectionMode = MenuSelectionMode.KeyString; // KeyString: User types a key, Arrow: User selects with arrow
               cfg.KeyStringTextSeparator = ": ";
               cfg.Title = "Main Menu";
           });
        }

        private MenuOptionResult GetTime()
        {
            Console.WriteLine($"The time is {DateTime.Now}");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        //string name, decimal price, int stockCount, string slotId
        public MenuOptionResult DisplayItems()
        {
            foreach (KeyValuePair<string, VendingMachineItems> kvp in ourVendingMachine.TotalInventoryList)
            {
                Console.WriteLine($"{kvp.Key} {kvp.Value.ProductType}     Remaining Quantity:{kvp.Value.StockCount} \t {kvp.Value.Name} {kvp.Value.Price} ");// This is where we left off!                   
            }
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        private MenuOptionResult Greeting()
        {
            string name = GetString("What is your name? ");
            Console.WriteLine($"Hello, {name}!");
            return MenuOptionResult.WaitAfterMenuSelection;
        }

        public MenuOptionResult ExitStatement()
        {
            PurchaseMenu purchaseMenu = new PurchaseMenu();
            purchaseMenu.ourVendingMachine = this.ourVendingMachine;
            purchaseMenu.Show();
            Console.WriteLine($"Here's your Change Amount: {ourVendingMachine.Balance}");        

            decimal twentyDollarBill = 20M;
            decimal tenDollarBill = 10M;
            decimal fiveDollarBill = 5M;
            decimal oneDollarBill = 1M;
            decimal quarter = 0.25M;
            decimal dime = 0.10M;
            decimal nickel = 0.05M;
            //decimal userChangeBalance = Balance;
            int twentyDollarCount = 0;
            int tenDollarBillCount = 0;
            int fiveDollarBillCount = 0;
            int oneDollarBillCount = 0;
            int quarterCount = 0;
            int dimeCount = 0;
            int nickelCount = 0;


            for (decimal i = 0M; i >= 0; i++)
            {
                if (ourVendingMachine.Balance >= twentyDollarBill)
                {
                    ourVendingMachine.Balance = ourVendingMachine.Balance - twentyDollarBill;
                    twentyDollarCount++;
                    //Console.WriteLine($"Twenty Dollar Bills: {twentyDollarCount}");
                }
                else if (ourVendingMachine.Balance >= tenDollarBill && ourVendingMachine.Balance < twentyDollarBill)
                {
                    ourVendingMachine.Balance = ourVendingMachine.Balance - tenDollarBill;
                    tenDollarBillCount++;
                }
                else if (ourVendingMachine.Balance >= fiveDollarBill && ourVendingMachine.Balance < tenDollarBill)
                {
                    ourVendingMachine.Balance = ourVendingMachine.Balance - fiveDollarBill;
                    fiveDollarBillCount++;
                    //Console.WriteLine(fiveDollarBillCount);
                }
                else if (ourVendingMachine.Balance >= oneDollarBill && ourVendingMachine.Balance < fiveDollarBill)
                {
                    ourVendingMachine.Balance = ourVendingMachine.Balance - oneDollarBill;
                    oneDollarBillCount++;
                }
                else if (ourVendingMachine.Balance >= quarter && ourVendingMachine.Balance < oneDollarBill)
                {
                    ourVendingMachine.Balance = ourVendingMachine.Balance - quarter;
                    quarterCount++;
                    //Console.WriteLine(quarterCount);
                }
                else if (ourVendingMachine.Balance >= dime && ourVendingMachine.Balance < quarter)
                {
                    ourVendingMachine.Balance = ourVendingMachine.Balance - dime;
                    dimeCount++;
                    //Console.WriteLine(dimeCount);
                }
                else if (ourVendingMachine.Balance >= nickel && ourVendingMachine.Balance < dime)
                {
                    ourVendingMachine.Balance = ourVendingMachine.Balance - nickel;
                    nickelCount++;
                }
                else
                {
                    break;
                }



            }

            Console.WriteLine($"Twenty Dollar Bills: {twentyDollarCount}");
            Console.WriteLine($"Ten Dollar Bills: {tenDollarBillCount}");
            Console.WriteLine($"Five Dollar Bills: {fiveDollarBillCount}");
            Console.WriteLine($"One Dollar Bills: {oneDollarBillCount}");
            Console.WriteLine($"Quarters: {quarterCount}");
            Console.WriteLine($"Dimes: {dimeCount}");
            Console.WriteLine($"Nickels: {nickelCount}");

            return MenuOptionResult.WaitAfterMenuSelection;
        }

    }
}







//public MainMenu()
//{
//    // Add Sample menu options
//    AddOption("Greeting", Greeting, "G");
//    AddOption("Show the Time", GetTime, "T");
//    AddOption("Quit", Close, "Q");

//    Configure(cfg =>
//    {
//        cfg.ItemForegroundColor = ConsoleColor.Cyan;
//        cfg.MenuSelectionMode = MenuSelectionMode.KeyString; // KeyString: User types a key, Arrow: User selects with arrow
//        cfg.KeyStringTextSeparator = ": ";
//        cfg.Title = "Main Menu";
//    });
//}

//private MenuOptionResult GetTime()
//{
//    Console.WriteLine($"The time is {DateTime.Now}");
//    return MenuOptionResult.WaitAfterMenuSelection;
//}

//private MenuOptionResult Greeting()
//{
//    string name = GetString("What is your name? ");
//    Console.WriteLine($"Hello, {name}!");
//    return MenuOptionResult.WaitAfterMenuSelection;