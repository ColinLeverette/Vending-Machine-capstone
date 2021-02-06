using Capstone.classes;     // could possibly ruin future code maybe mabye not
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MenuFramework;
using Capstone.CLI;

namespace Capstone
{

    public class VendingMachine
    {
        public decimal Balance { get; set; }

        string filePath = @"C:\Users\Student\git\c-module-1-capstone-team-2\19_Capstone\vendingmachine.csv";

        public Dictionary<string, VendingMachineItems> TotalInventoryList = new Dictionary<string, VendingMachineItems>();

        

        public void CurrentMoneyProvided(decimal moneyEntered)
        {
            Balance = moneyEntered + Balance;
        }

        //public void ErrorWrongChoiceMethod(string slotCode)
        //{
        //    Console.WriteLine("Error! Incorrect Choice. Please Try Again.");
        //}
        public MenuOptionResult UserItemChoice(string userCodeEntered)
        {
            //Each slot has a starting stock of 5
            // subtracts however many are bought from the defualt stock
            //Console.WriteLine("What would you like to purchase? (ex: A1, C3, B1) ");
            //string userPurchaseChoice = Console.ReadLine();
            PurchaseMenu purchaseMenu = new PurchaseMenu();

            if (TotalInventoryList.ContainsKey((userCodeEntered.ToUpper())) == false)
            {
                purchaseMenu.WrongSlotIdEnteredError();
            }
            foreach (KeyValuePair<string, VendingMachineItems> kvp in TotalInventoryList)
            {            
                if (kvp.Key.Contains(userCodeEntered.ToUpper())) /*&& (kvp.Value.StockCount > 0 && Balance >= kvp.Value.Price))*/
                {
                    if (kvp.Value.StockCount > 0 && Balance >= kvp.Value.Price)
                    {
                        kvp.Value.StockCount -= 1;
                        Balance = Balance - kvp.Value.Price;                        
                        purchaseMenu.ItemChoiceDisplayMessage(kvp.Value.ProductType, kvp.Value.Name, kvp.Value.Price, Balance);
                        
                        
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

                        //Take them back to the purchase menu
                        return MenuOptionResult.WaitAfterMenuSelection;
                    }
                    else if (Balance < kvp.Value.Price)
                    {
                        purchaseMenu.InsufficientFundsMessage();
                    }
                    else if (kvp.Value.StockCount == 0)
                    {
                        {
                            purchaseMenu.NotEnoughStock();
                            return MenuOptionResult.WaitAfterMenuSelection;
                        }
                    }
                }              
            }
            // TODO check if this is a thing delete potentially ErrorWrongChoiceMethod(userCodeEntered);           
            return MenuOptionResult.WaitAfterMenuSelection;
        }




        public void ReadFile()
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
                    TotalInventoryList.Add(lineSplit[0], item);


                    //A1 | Potato Crisps | 3.05 | Chip
                    //B1 | Moonpie | 1.80 | Candy
                    //B2 | Cowtales | 1.50 | Candy
                    //C1 | Cola | 1.25 | Drink

                }
            }
        }

        public void AuditLog(string action, decimal balance)
        {
            string outPath = "../../../../Log.txt";

            using (StreamWriter writer = new StreamWriter(outPath, true))
            {               
                DateTime now = new DateTime();
                writer.WriteLine($"{now} {action}: {balance} {Balance}");
                    
            }
        }

        public decimal GetBalance()
        {
            return this.Balance;
        }

    }
}








