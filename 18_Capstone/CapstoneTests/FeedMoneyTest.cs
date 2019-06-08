using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class FeedMoneyTest
    {
        [TestMethod]
        public void TestingToMakeSureBalanceIncreasesAfterUserInputsMoney()
        {
            // Arrange

            //creates new vending machine to test our method
            VendingMachine testMachine = new VendingMachine();

            // Act
            
            // we expect these two values to match since it is one of our accepted bills and we can add it.
            decimal testCase = 0;
            decimal moneyInput = 10;
            testMachine.Balance = 0;
            testMachine.FeedMoney(moneyInput);



            // Assert

            // Shows we added the moneyInput value of 10.00 using our method.
            Assert.AreNotEqual(testCase, testMachine.Balance , "User entered invalid bill.");
            
        }
    }
}
