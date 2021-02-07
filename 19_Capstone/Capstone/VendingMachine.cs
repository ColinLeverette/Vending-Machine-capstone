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
        // Error message constants 
        public const string INVALID_SLOT_MESSAGE = "Wrong Slot ID entered";
        public const string INSUFFICIENT_FUNDS_MESSAGE = "Insufficient Funds";
        public const string OUT_OF_STOCK_MESSAGE = "Not enough stock";
        
        // setting initial balance to 0
        public decimal Balance { get; set; } = 0;

        string filePath = @"C:\Users\Student\git\c-module-1-capstone-team-2\19_Capstone\vendingmachine.csv";

        public Dictionary<string, VendingMachineItems> TotalInventoryDictionary = new Dictionary<string, VendingMachineItems>();


        public decimal AddMoney(decimal moneyEntered)   // Adds user's money and increases balance
        {
            Balance = Balance + moneyEntered;
            return Balance;
        }

        public decimal RunningBalanceMethod(decimal userMoneyEntered)  // Sets a running balance equal to balance + money entered by user
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
        
        public VendingMachineItems UserItemChoice(string userCodeEntered)  
        {
            userCodeEntered = userCodeEntered.ToUpper();
            
            if (TotalInventoryDictionary.ContainsKey(userCodeEntered))
            {
                VendingMachineItems selectedItem = TotalInventoryDictionary[userCodeEntered];
                AuditLogPurchaseMethod(selectedItem.Name, selectedItem.SlotId, Balance, Balance - selectedItem.Price); 
            
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
        }

        public List<string> ReadFileNew()  // Reads from the file and adds to restock list line by line
        {
            List<string> restockList = new List<string>();
            using (StreamReader reader = new StreamReader(@"C:\Users\Student\git\c-module-1-capstone-team-2\19_Capstone\vendingmachine.csv"))
            {
                while (!reader.EndOfStream)
                {
                    string inventoryLine = reader.ReadLine(); // Reads every line and assigns the whole line to the string

                    restockList.Add(inventoryLine);

                }
                //read all the lines from the file, return them as a list of strings
                return restockList;
            }
        }

        public void RestockFromLines(List<string> fileLines) // we take our list of strings and loop through it 
            // make a new machineitems. we split the list and set that to an array. set the indexes of the array to to the properties in the new machine
            // then add the item to the new dictionary. 
        {
            foreach (string line in fileLines)
            {
                VendingMachineItems newItem = new VendingMachineItems();

                string[] lineSplit = line.Split("|");

                newItem.Name = lineSplit[1];
                newItem.Price = decimal.Parse(lineSplit[2]);
                newItem.SlotId = lineSplit[0];
                newItem.ProductType = lineSplit[3];
                newItem.StockCount = 5;

                TotalInventoryDictionary.Add(lineSplit[0], newItem);
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

       
    }

}

