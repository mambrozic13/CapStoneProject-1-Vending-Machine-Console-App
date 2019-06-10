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
            VendingMachine testMachine = new VendingMachine();

            // Act
            decimal testCase = 0;
            decimal moneyInput = 10;
            testMachine.Balance = 0;
            testMachine.FeedMoney(moneyInput);



            // Assert
            Assert.AreNotEqual(testCase, testMachine.Balance , "User entered invalid bill.");
            
        }
    }
}
