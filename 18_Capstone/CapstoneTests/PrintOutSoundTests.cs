﻿using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{

    [TestClass]
    public class PrintOutSoundTests
    {
        [TestMethod]
        public void TestingThatCorrectSoundDisplays()
        {

            // Arrange
            VendingMachine vm = new VendingMachine();
            Product product = new Product("Potato Crisps", 3.05M, "Chip");
            Stock item = new Stock(product, 5, "A1");
            List<Stock> RemovedItems = new List<Stock>();
            

            // Act
            RemovedItems.Add(item);
            string actualResult = vm.PrintOutSoundForEachPurchase(RemovedItems);
            string expectedTestResult = "Crunch Crunch, Yum!";

            // Assert
            Assert.AreEqual(expectedTestResult, actualResult);


        }
    }
}
