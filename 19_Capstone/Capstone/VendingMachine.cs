using Capstone.classes;     // could possibly ruin future code maybe mabye not
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{

    public class VendingMachine
    {
        public decimal Balance { get; set; }



        string filePath = @"C:\Users\Student\git\c-module-1-capstone-team-2\19_Capstone\vendingmachine.csv";

        List<VendingMachineItems> InventoryList = new List<VendingMachineItems>();

        public void ReadFile(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))

            {
                while (!reader.EndOfStream)
                {
                    string inventoryLine = reader.ReadLine();

                    string[] lineSplit = inventoryLine.Split("|");
                    

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



