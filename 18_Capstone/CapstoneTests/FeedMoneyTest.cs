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
            
            // we expect these two values not to match since it is one of our accepted bills and we can add it.
            decimal testCase = 10.00M;
            testMachine.Balance = 10;
            testMachine.FeedMoney(testCase);



            // Assert

            // Shows we added the testCase value of 10.00 using our method.
            Assert.AreNotEqual(testCase, testMachine.Balance , "User entered invalid bill.");
            
        }
    }
}
