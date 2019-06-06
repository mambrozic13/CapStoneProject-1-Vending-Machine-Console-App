using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Stock
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }

        public Stock (Product product, int quantity, string location)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.Location = location;
        }
    }
}
