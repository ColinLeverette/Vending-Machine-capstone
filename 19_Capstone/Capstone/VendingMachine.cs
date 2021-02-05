using Capstone.classes;     // could possibly ruin future code maybe mabye not
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using MenuFramework;


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

        public MenuOptionResult CheckIfItemIsAvailable()
        {
            //Each slot has a starting stock of 5
            // subtracts however many are bought from the defualt stock
            Console.WriteLine("What would you like to purchase? (ex: A1, C3, B1) ");
            string userPurchaseChoice = Console.ReadLine();

            foreach (KeyValuePair<string, VendingMachineItems> kvp in TotalInventoryList)
            {

                if (kvp.Key.Contains(userPurchaseChoice))
                {
                    if (kvp.Value.StockCount >= 1 && Balance >= kvp.Value.Price)
                    {
                        kvp.Value.StockCount -= 1;
                        Balance = Balance - kvp.Value.Price;
                        //Take them back to the purchase menu
                        break;
                    }


                    //if money provided is greater than the price (DONE)
                    //balance decreases (DONE)
                    break;
                }
                break;
                Console.WriteLine("Error! Incorrect Choice. Please Try Again.");

            }

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

}

}



//using (StreamReader reader = new StreamReader(fileName))
//{
//    while (!reader.EndOfStream)            // while NOT at the end of the stream
//    {
//        // read the next line
//        string input = reader.ReadLine();

//        // split the line into individual fields
//        string[] fields = input.Split("|");

//        string stateName = fields[0];
//        string stateCode = fields[1];
//        string capital = fields[2];
//        string largest = fields[3];

//        State state = new State(stateCode, stateName, capital, largest);
//        stateList.Add(state);



