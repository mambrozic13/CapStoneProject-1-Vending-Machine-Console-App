using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests
{
    [TestClass]
    public class ProductConstructorTests
    {
        [TestMethod]
        public void TestProductClassConstructor()
        {
            // Arrange
            // No arrangement needed.


            // Act
            Product product = new Product("Potato Crisps", 3.05M, "Chip");


            // Assert
            Assert.AreEqual("Potato Crisps", product.Name, "The Name of the product is invalid.");
            Assert.AreNotEqual(4.0M, product.Price, "The price of the product was invalid.");
            Assert.AreEqual("Chip", product.Category, "The name of the category is invalid.");

        }
    }
}
