using Capstone;
using Capstone.classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;


namespace CapstoneTests
{ [TestClass]


    public class FinancialTransactionTests
    {
        [DataTestMethod]
        [DataRow("ponpoadnjpofnpounfapdosunpadsougn", "Wrong Slot ID entered")]
        [DataRow("a1", "")]



        public void SufficientFundsTest(string firstInput, string expectedResult)
        {
            // arrange
            VendingMachine vendingMachineTest = new VendingMachine();


            // act
            string resultOfTest = vendingMachineTest.UserItemChoice(firstInput).ToString();

            // assert
            Assert.AreEqual(expectedResult, resultOfTest);

        }

        [DataTestMethod]
        [DataRow(5.0, 5.0)]
        [DataRow(0.0, 0.0)]
        [DataRow(100.0, 100.0)]


        public void MoneyProvidedMethodTest (double moneyEntered, double expected)
        {
            VendingMachine inputMoneytest = new VendingMachine();

            decimal resultOfTest = inputMoneytest.CurrentMoneyProvided((decimal)moneyEntered);


            Assert.AreEqual((decimal)expected, resultOfTest);

        }

        [DataTestMethod]
        [DataRow(5.0,5.0)]
        [DataRow(0.0, 0.0)]
        [DataRow(100.0, 100.0)]

        public void RunningBalancedMethodTest(double usermoneyEntered, double expected)
        {
            VendingMachine inputMoneytest = new VendingMachine();

            decimal resultOfTest = inputMoneytest.CurrentMoneyProvided((decimal)usermoneyEntered);


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
