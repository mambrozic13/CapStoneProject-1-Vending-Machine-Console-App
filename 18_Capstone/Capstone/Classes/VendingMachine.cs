using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine 
    {
        // dictionary we want to hold our stock
        private Dictionary<string, Stock> InternalStockList = new Dictionary<string, Stock>(); 
        public Stock[] StockList
        {
            get
            {
                List<Stock> tempList = new List<Stock>();
                foreach (var dictionaryItem in InternalStockList)
                {
                    tempList.Add(dictionaryItem.Value);

                }
                return tempList.ToArray();
            }
        }
        
        // the location of the file holding our stock
        public string path = @"C:\Users\MSpring\Git\c-module-1-capstone-team-3\18_Capstone\etc\vendingmachine.csv";

        
        public void Load()
        {
            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            string[] ProductNamePriceCat = line.Split("|");
                            Product product = new Product(ProductNamePriceCat[1], decimal.Parse(ProductNamePriceCat[2]), ProductNamePriceCat[3]);
                            Stock stock = new Stock(product, 5, ProductNamePriceCat[0]);
                            InternalStockList.Add(stock.Location, stock);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"There was an format exception loading the stock list from the {path}. This stock list was not completely loaded.");
                }

            }
        }


        
        public decimal Balance { get; set; } 

        public decimal moneyInput = 0;
        public void FeedMoney(decimal moneyInput)
        {
            Balance += moneyInput;
        }


        // ?? gets added when we try to access our VM class in main menu
        public VendingMachine()
        {
        }
    }
}
