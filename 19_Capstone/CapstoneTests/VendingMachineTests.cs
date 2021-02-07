using Capstone;
using Capstone.classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

// make 4 tests userItemChoice_Test_GoodData  useritemchoise_test_slotnotfound  useritemchoice_test_insufficientfunds useritemchoice_test_out of stock
namespace CapstoneTests
{ [TestClass]


    public class VendingMachineTests
    {
        private List<string> sampleStockFileLines = new List<string>()
    {
        "A1|M&Ms|3.05|Candy", // list[0]
        "A2|Doritos|4.20|Chip", // list[1]
        "B1|Sprite|2.75|Drink", // list[2]
        "B2|Big Chew|3.65|Gum" // List[3]

            // test always works with hard coded inventory, prevents people from chaing the items in CSV. 
            // testing it the old way is difficult because i have to read from a file i/o exceptions, csv coulda changed, flexibility in testing. I can test different scenarios and dictionaries. test what happens if list is empty. can make empty list 
    };


        [TestMethod]
        public void UserItemChoice_Test_GoodData()
        {
            //Arrange
            VendingMachine testVendingMachine = new VendingMachine();
            testVendingMachine.RestockFromLines(sampleStockFileLines);
            testVendingMachine.AddMoney(20M);
            string expectedItemName = "M&Ms";
            decimal expectedItemPrice = 3.05M;
            string expectedItemCategory = "Candy";


            //Act
            VendingMachineItems resultItem = testVendingMachine.UserItemChoice("A1");

            // Assert
            Assert.AreEqual(expectedItemName, resultItem.Name);
            Assert.AreEqual(expectedItemPrice, resultItem.Price);
            Assert.AreEqual(expectedItemCategory, resultItem.ProductType);



        }
        [TestMethod]
        
        public void UserItemChoice_Test_SlotNotFound()
        {
            //Arrange
            VendingMachine testVendingMachine = new VendingMachine();
            testVendingMachine.RestockFromLines(sampleStockFileLines);
            testVendingMachine.AddMoney(20M);
            Exception e = new Exception("");

            //Act 
            try
            {
                VendingMachineItems resultItem = testVendingMachine.UserItemChoice("Z6");

            }
            catch (Exception f)// catch insufficient funds error
            {
                e = f; // effectively makes e message "INVALID SlotMEssage"
            }
            //Assert
            Assert.AreEqual(e.Message, VendingMachine.INVALID_SLOT_MESSAGE);
        }
        [TestMethod]
        public void UserItemChoice_Test_InsufficientFunds()// surround user item choice in try catch, assert equals exception e.message, to invalid not enough money 
        {
            // Arrange
            VendingMachine testVendingMachine = new VendingMachine();
            testVendingMachine.RestockFromLines(sampleStockFileLines);
            //testVendingMachine.AddMoney(20M); // if this is uncommented this test will fail 
            Exception e = new Exception("");

            //Act 
            try
            {
                VendingMachineItems resultItem = testVendingMachine.UserItemChoice("A1");

            }
            catch (Exception f)// catch insufficient funds error
            {
                e = f; // effectively makes e message "insufficient funds"
            }
            //Assert
            Assert.AreEqual(e.Message,VendingMachine.INSUFFICIENT_FUNDS_MESSAGE);


        }
        [TestMethod]
        public void UserItemChoice_Test_OutOfStock()
        {

        }

       



      

        [DataTestMethod]
        [DataRow(5.0, 5.0)]
        [DataRow(0.0, 0.0)]
        [DataRow(100.0, 100.0)]


        public void MoneyProvidedMethodTest (double moneyEntered, double expected)
        {
            VendingMachine inputMoneytest = new VendingMachine();

            decimal resultOfTest = inputMoneytest.AddMoney((decimal)moneyEntered);


            Assert.AreEqual((decimal)expected, resultOfTest);

        }

        [DataTestMethod]
        [DataRow(5.0,5.0)]
        [DataRow(0.0, 0.0)]
        [DataRow(100.0, 100.0)]

        public void InputMoney_Test(double usermoneyEntered, double expected)
        {
            VendingMachine inputMoneytest = new VendingMachine();

            decimal resultOfTest = inputMoneytest.AddMoney((decimal)usermoneyEntered);


            Assert.AreEqual((decimal)expected, resultOfTest);

        }

    }
}
//public decimal RunningBalanceMethod(decimal userMoneyEntered)
//{
//    decimal runningBalance;
//    runningBalance = Balance + userMoneyEntered;
//    return runningBalance;
//}
