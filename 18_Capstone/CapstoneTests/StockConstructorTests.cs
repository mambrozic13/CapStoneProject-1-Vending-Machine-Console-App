using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class StockConstructorTests
    {
        [TestMethod]
        public void StockClassConstructorTest()
        {
            // Arrange
            // No arrangement needed.
            
            // Act
            Product testProductExpectedToPass = new Product("Potato Crisps", 3.05M, "Chip");
            Product testProductExpectedToFail = new Product("Wanka Bar", 5.00M, "Candy");
            Stock testStockClass = new Stock(testProductExpectedToPass, 5, "A1");


            // Assert
            Assert.AreEqual(5, testStockClass.Quantity, "Invalid quantity amount. All stock must start with a quantity of 5.");
            Assert.AreNotEqual(3, testStockClass.Quantity, "Invalid quantity amount. All stock must start with a quantity of 5.");
            Assert.AreEqual("A1", testStockClass.Location, "Incorrect location of stock.");
            Assert.AreNotEqual("B3", testStockClass.Location, "Incorrect location of stock.");
            Assert.AreEqual(testProductExpectedToPass, testStockClass.Product, "Inncorrect Product belonging to this Stock.");
            Assert.AreNotEqual(testProductExpectedToFail, testStockClass.Product, "Inncorrect Product belonging to this Stock.");
        }

    }
}
