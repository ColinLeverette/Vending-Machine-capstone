using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;


namespace CapstoneTests
{ [TestClass]


    public class FinancialTransactionTests
    {
        [DataTestMethod]
        [DataRow("ponpoadnjpofnpounfapdosunpadsougn", "WaitAfterMenuSelection")]


        public void SufficientFundsTest(string firstInput, string expectedResult)
        {
            // arrange
            VendingMachine vendingMachineTest = new VendingMachine();


            // act
            string resultOfTest = vendingMachineTest.UserItemChoice(firstInput).ToString();

            // assert
            Assert.AreEqual(expectedResult, resultOfTest);

        }

        [TestMethod]
        

        public void MoneyProvidedMethodTest (decimal moneyEntered, decimal expected)
        {
            VendingMachine inputMoneytest = new VendingMachine();

            decimal resultOfTest = inputMoneytest.CurrentMoneyProvided(moneyEntered);


            Assert.AreEqual(expected, resultOfTest);

        }

        [TestMethod]


        public void RunningBalancedMethodTest(decimal usermoneyEntered, decimal expected)
        {
            VendingMachine inputMoneytest = new VendingMachine();

            decimal resultOfTest = inputMoneytest.CurrentMoneyProvided(usermoneyEntered);


            Assert.AreEqual(expected, resultOfTest);

        }

    }
}
//public decimal RunningBalanceMethod(decimal userMoneyEntered)
//{
//    decimal runningBalance;
//    runningBalance = Balance + userMoneyEntered;
//    return runningBalance;
//}
