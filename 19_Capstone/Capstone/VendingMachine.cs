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

        //public void GiveChangeMethod(decimal balance)
        //{

        //    decimal twentyDollarBill = 20M;
        //    decimal tenDollarBill = 10M;
        //    decimal fiveDollarBill = 5M;
        //    decimal oneDollarBill = 1M;
        //    decimal quarter = 0.25M;
        //    decimal dime = 0.10M;
        //    decimal nickel = 0.05M;
        //    //decimal userChangeBalance = Balance;
        //    int twentyDollarCount = 0;
        //    int tenDollarBillCount = 0;
        //    int fiveDollarBillCount = 0;
        //    int oneDollarBillCount = 0;
        //    int quarterCount = 0;
        //    int dimeCount = 0;
        //    int nickelCount = 0;


        //    for (decimal i = 0M; i > 0; i++)
        //    {
        //        if (balance >= twentyDollarBill)
        //        {
        //            balance = balance - twentyDollarBill;
        //            twentyDollarCount++;
        //        }
        //        else if (balance >= tenDollarBill && balance < twentyDollarBill)
        //        {
        //            balance = balance - tenDollarBill;
        //            tenDollarBillCount++;
        //        }
        //        else if (balance >= fiveDollarBill && balance < tenDollarBill)
        //        {
        //            balance = balance - fiveDollarBill;
        //            fiveDollarBillCount++;
        //        }
        //        else if (balance >= oneDollarBill && balance < fiveDollarBill)
        //        {
        //            balance = balance - oneDollarBill;
        //            oneDollarBillCount++;
        //        }
        //        else if (balance >= quarter && balance < oneDollarBill)
        //        {
        //            balance = balance - quarter;
        //            quarterCount++;
        //        }
        //        else if (balance >= dime && balance < quarter)
        //        {
        //            balance = balance - dime;
        //            dimeCount++;
        //        }
        //        else if (balance >= nickel && balance < dime)
        //        {
        //            balance = balance - nickel;
        //            nickelCount++;
        //        }
        //        Console.WriteLine(twentyDollarCount);
        //        Console.WriteLine(tenDollarBillCount);
        //        Console.WriteLine(fiveDollarBillCount);
        //        Console.WriteLine(oneDollarBillCount);
        //        Console.WriteLine(quarterCount);
        //        Console.WriteLine(dimeCount);
        //        Console.WriteLine(nickelCount);
                


        //    }


        //}


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

            foreach (KeyValuePair<string, VendingMachineItems> kvp in TotalInventoryList)
            {

                if (kvp.Key.Contains(userCodeEntered.ToUpper()))
                {
                    if (kvp.Value.StockCount >= 1 && Balance >= kvp.Value.Price)
                    {
                        kvp.Value.StockCount -= 1;
                        Balance = Balance - kvp.Value.Price;
                        //Take them back to the purchase menu

                    }


                    //if money provided is greater than the price (DONE)
                    //balance decreases (DONE)

                }
                //ErrorWrongChoiceMethod(userCodeEntered);

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



