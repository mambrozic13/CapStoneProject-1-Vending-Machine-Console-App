using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Product
    {
        public Product(string name, decimal price, string category)
        {
            this.Name = name;
            this.Price = price;
            this.Category = category;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }


    }
}
