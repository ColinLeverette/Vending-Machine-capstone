using Capstone.classes;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MenuFramework;
using Capstone.CLI;
using System;

namespace Capstone
{

    public class VendingMachine
    {

        public const string INVALID_SLOT_MESSAGE = "Wrong Slot ID entered";
        public const string INSUFFICIENT_FUNDS_MESSAGE = "Insufficient Funds";
        public const string OUT_OF_STOCK_MESSAGE = "Not enough stock";

        public decimal Balance { get; set; } = 0;

        string filePath = @"C:\Users\Student\git\c-module-1-capstone-team-2\19_Capstone\vendingmachine.csv";

        public Dictionary<string, VendingMachineItems> TotalInventoryDictionary = new Dictionary<string, VendingMachineItems>();



        public decimal CurrentMoneyProvided(decimal moneyEntered) // dont touch
        {
            // initialBalance = 0;
            Balance = Balance + moneyEntered;
            return Balance;
        }

        public decimal RunningBalanceMethod(decimal userMoneyEntered)
        {
            decimal runningBalance;
            runningBalance = Balance + userMoneyEntered;
            return runningBalance;
        }

        /// <summary>
        /// -Checks user code input (ex: "A1", "B4")
        /// -if code matches from the list-  dispense item and update balance
        /// - if code does not match, release error message.
        /// </summary>
        /// <param name="userCodeEntered">this is the code that the user entered</param>
        /// <returns></returns>
        public VendingMachineItems UserItemChoice(string userCodeEntered) // MENU OPTION RESULT is the type
        {
            userCodeEntered = userCodeEntered.ToUpper();
            //PurchaseMenu purchaseMenu = new PurchaseMenu();
            // (userCodeEntered.Length <= 1 ||
            //if (TotalInventoryDictionary.ContainsKey(userCodeEntered.ToUpper()) == false)
            //{
            //    throw new Exception(INVALID_SLOT_MESSAGE);
            //    //purchaseMenu.WrongSlotIdEnteredError();
            //}

            //foreach (KeyValuePair<string, VendingMachineItems> kvp in TotalInventoryDictionary)
            //{


            if (TotalInventoryDictionary.ContainsKey(userCodeEntered))
            {
                VendingMachineItems selectedItem = TotalInventoryDictionary[userCodeEntered];

                if (selectedItem.StockCount == 0)
                {
                    throw new Exception(OUT_OF_STOCK_MESSAGE);
                }
                else if (Balance < selectedItem.Price)
                {
                    throw new Exception(INSUFFICIENT_FUNDS_MESSAGE);
                }
                selectedItem.StockCount -= 1;
                Balance -= selectedItem.Price; 
                return selectedItem;
            }
            else { throw new Exception(INVALID_SLOT_MESSAGE); }
            
            //        
            //      return selectedItem
            //else
            //                        {
            //       //item not found
            //         return null




            //    if (TotalInventoryDictionary.ContainsKey(userCodeEntered)) /*&& (kvp.Value.StockCount > 0 && Balance >= kvp.Value.Price))*/
            //    {
            //        if (kvp.Value.StockCount > 0 && Balance >= kvp.Value.Price)
            //        {
            //            kvp.Value.StockCount -= 1;
            //            Balance -= kvp.Value.Price;               

            //            //purchaseMenu.ItemChoiceDisplayMessage(kvp.Value.ProductType, kvp.Value.Name, kvp.Value.Price, Balance);
            //            AuditLogPurchaseMethod(kvp.Value.Name, kvp.Key, RunningBalanceMethod(kvp.Value.Price), Balance);
            //            return kvp.Value;

            //            //Take them back to the purchase menu
            //            //return MenuOptionResult.WaitAfterMenuSelection; ORIGINAL CHANGE BACK
            //        }
            //        else if (Balance < kvp.Value.Price)
            //        {
            //            throw new Exception(INSUFFICIENT_FUNDS_MESSAGE);
            //            //purchaseMenu.InsufficientFundsMessage();
            //        }
            //        else if (kvp.Value.StockCount == 0)
            //        {

            //            throw new Exception(OUT_OF_STOCK_MESSAGE);
            //            //purchaseMenu.NotEnoughStock();
            //                //return MenuOptionResult.WaitAfterMenuSelection; ORIGINAL CHANGE BACK

            //        }
            //        return null;
            //    }              
            //}
            return null;
            // TODO check if this is a thing delete potentially ErrorWrongChoiceMethod(userCodeEntered);           
            //return MenuOptionResult.WaitAfterMenuSelection; ORIGINAL CHANGE BACK
        }

        public List<string> ReadFileNew()
        {
            using (StreamReader reader = new StreamReader(@"C:\Users\Student\git\c-module-1-capstone-team-2\19_Capstone\vendingmachine.csv"))
            {
                while (!reader.EndOfStream)
                {
                    string inventoryLine = reader.ReadLine(); // Reads every line and assigns the whole line to the string

                    string[] lineSplit = inventoryLine.Split("|");// splits the string into an array. 

                    string productName = lineSplit[1];
                    decimal itemPrice = decimal.Parse(lineSplit[2]);
                    string slotId = lineSplit[0];
                    string productType = lineSplit[3];

                    //VendingMachineItems item = new VendingMachineItems(productName, itemPrice, 5, slotId);
                    VendingMachineItems item = new VendingMachineItems();


                    item.Name = lineSplit[1];
                    item.Price = decimal.Parse(lineSplit[2]);
                    item.SlotId = lineSplit[0];
                    item.ProductType = lineSplit[3];
                    item.StockCount = 5;

                    //(lineSplit[1], decimal.Parse(lineSplit[2]), 5, lineSplit[0], lineSplit[3])
                    TotalInventoryDictionary.Add(lineSplit[0], item);
                }
                //read all the lines from the file, return them as a list of strings
                return null;
        }

        public void RestockFromLines(List<string> fileLines)
        {
            foreach (string line in fileLines)
            {

                //add a new vendingMachine item with string.split("|")
            }
        }
        
        public void ReadFileOld()

        {
            using (StreamReader reader = new StreamReader(@"C:\Users\Student\git\c-module-1-capstone-team-2\19_Capstone\vendingmachine.csv"))

            {
                while (!reader.EndOfStream)
                {
                    string inventoryLine = reader.ReadLine(); // Reads every line and assigns the whole line to the string

                    string[] lineSplit = inventoryLine.Split("|");// splits the string into an array. 

                    string productName = lineSplit[1];
                    decimal itemPrice = decimal.Parse(lineSplit[2]);
                    string slotId = lineSplit[0];
                    string productType = lineSplit[3];

                    //VendingMachineItems item = new VendingMachineItems(productName, itemPrice, 5, slotId);
                    VendingMachineItems item = new VendingMachineItems();


                    item.Name = lineSplit[1];
                    item.Price = decimal.Parse(lineSplit[2]);
                    item.SlotId = lineSplit[0];
                    item.ProductType = lineSplit[3];
                    item.StockCount = 5;

                    //(lineSplit[1], decimal.Parse(lineSplit[2]), 5, lineSplit[0], lineSplit[3])
                    TotalInventoryDictionary.Add(lineSplit[0], item);


                    //A1 | Potato Crisps | 3.05 | Chip
                    //B1 | Moonpie | 1.80 | Candy
                    //B2 | Cowtales | 1.50 | Candy
                    //C1 | Cola | 1.25 | Drink

                }
            }
        }

        public void AuditLogFeedMoney(string action, decimal initialBalance, decimal runningBalance)
        {
            string outPath = "../../../../Log.txt";

            using (StreamWriter writer = new StreamWriter(outPath, true))
            {
                DateTime now = new DateTime();
                writer.WriteLine($"{DateTime.Now} {action} {initialBalance} {runningBalance}");

            }
        }

        public void AuditLogPurchaseMethod(string action, string slotId, decimal currentBalance, decimal updatedBalance)
        {
            string outPath = "../../../../Log.txt";

            using (StreamWriter writer = new StreamWriter(outPath, true))
            {
                DateTime now = new DateTime();
                writer.WriteLine($"{DateTime.Now} {action} {slotId}  {currentBalance} {updatedBalance}");
            }
        }


        public void AuditLogGiveChangeMethod(string action, decimal currentBalance, decimal updatedBalance)
        {
            string outPath = "../../../../Log.txt";

            using (StreamWriter writer = new StreamWriter(outPath, true))
            {
                writer.WriteLine($"{DateTime.Now} {action} {currentBalance} {updatedBalance}");
            }
        }

        public decimal GetBalance()
        {
            return this.Balance;
        }

    }
}

//if (kvp.Value.ProductType == "Gum")
//{
//    Console.WriteLine($"Item Name: {kvp.Value.Name}");
//    Console.WriteLine($"Item Price: {kvp.Value.Price}");
//    Console.WriteLine($"Remaining Balance: ${Balance}");

//    purchaseMenu.GumPurchaseMessage();
//}
//if (kvp.Value.ProductType == "Drink")
//{
//    Console.WriteLine($"Item Name: {kvp.Value.Name}");
//    Console.WriteLine($"Item Price: {kvp.Value.Price}");
//    Console.WriteLine($"Remaining Balance: ${Balance}");
//    purchaseMenu.DrinkPurchaseMessage();
//}
//if (kvp.Value.ProductType == "Candy")
//{
//    Console.WriteLine($"Item Name: {kvp.Value.Name}");
//    Console.WriteLine($"Item Price: {kvp.Value.Price}");
//    Console.WriteLine($"Remaining Balance: ${Balance}");
//    purchaseMenu.CandyPurchaseMessage();
//}
//if (kvp.Value.ProductType == "Chip")
//{
//    Console.WriteLine($"Item Name: {kvp.Value.Name}");
//    Console.WriteLine($"Item Price: {kvp.Value.Price}");
//    Console.WriteLine($"Remaining Balance: ${Balance}");
//    purchaseMenu.ChipsPurchaseMessage();
//}