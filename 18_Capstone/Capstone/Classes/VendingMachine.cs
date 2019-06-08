using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine 
    {
        // This is our Dictionary that holds our Vending Machine "stock"
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
        
        // These are the two paths we used that contains our file with the Vending Machine stock. We can then use this path to populate our dictionary.
        
        //public string path = @"C:\Users\MAmbrozic\Git\c-module-1-capstone-team-3\18_Capstone\etc\vendingmachine.csv";
        public string path = @"C:\Users\MSpring\Git\c-module-1-capstone-team-3\18_Capstone\etc\vendingmachine.csv";


        // Our method we created to populate our Vending Machine with the "stock" within our file.
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


        // This is our Balance. We use this in several different locations throughout our program.
        public decimal Balance { get; set; } 


        // This is the method we created to allow the user to input money and we then update our balance if the bill entered is an accepeted bill. (1,2,5,10)
        // This method is only called when the user makes selection 1 within our Purchase Menu.
        protected decimal billsEnteredForAudit = 0;
        public void FeedMoney(decimal moneyInput)
        {
            billsEnteredForAudit = moneyInput;
            if (moneyInput == 1 || moneyInput == 2 || moneyInput == 5 || moneyInput == 10)
            {
                Balance += moneyInput;
            }
            else
            {
                Console.WriteLine("Sorry you entered a bill we can't accept. Please try again.");
            }
        }



        // This is our method we created to Return Change to our user when they make selection 3 at the Purchase Menu.
        protected decimal changeForAudit = 0;
        public void ReturnChange(decimal balance)
        {

            changeForAudit = balance;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;

            Balance *= 100;
            while (Balance >= 25)
            {
                quarters++;
                Balance -= 25;
            }
            while (Balance >= 10)
            {
                dimes++;
                Balance -= 10;
            }
            while (Balance >= 5)
            {
                nickels++;
                Balance -= 5;
            }
            Console.WriteLine($"Enjoy! Please check the tray for you change. Quarters: {quarters}, Dimes: {dimes}, Nickels: {nickels}");
        }


        // Here we created a List to be able to track and hold the items(stock) that the user purchased. 
        // This way we had a list we could check and use later for other situations.
        List<Stock> RemovedItems = new List<Stock>();


        // Created a WriteLog for ourselves to use for all of the Audit Methods we use to track all user transactions and use of Vending Machine.
        private void WriteLog(string line)
        {
            using (StreamWriter AuditLog = new StreamWriter("Log.txt", true))
            {
                AuditLog.WriteLine(line);
            }
        }


        // This is our Method we originally created within our Purchase menu. 
        // I moved all the code here and created a method that did the same thing. Cleans up menu and puts this action where it belongs. 
        public void SelectProduct(string selectionInput)
        {
            bool itemExists = false;
            foreach (Stock item in StockList)
            {
                if (selectionInput == item.Location)
                {
                    itemExists = true;
                }
            }
            if (!itemExists)
            {
                Console.WriteLine("Sorry the selection you made does not exist. Please check the list and try again.\r\nPlease press enter to try again...");
                Console.ReadKey();
            }

            if (Balance > 0)
            {
                foreach (Stock item in StockList)
                {
                    if (selectionInput == item.Location)
                    {
                        if (Balance >= item.Product.Price)
                        {
                            if (item.Quantity > 0)
                            {
                                decimal initialBalance = Balance;

                                Console.WriteLine($"You Selected: {item.Product.Name}");
                                Console.ReadKey();

                                Balance -= item.Product.Price;
                                item.Quantity -= 1;
                                RemovedItems.Add(item);
                                // Audit for selection 2. Tried moving outside but no luck. Need access to item in foreach loop..
                                string line = $"{DateTime.Now}   {item.Product.Name} {selectionInput}    {initialBalance:C}      {Balance:C}  ";
                                WriteLog(line);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Sorry the item is Sold Out. Please make a new selection.");
                                Console.ReadKey();
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Insufficient Funds! Please feed more money into the machine before mkaing this purchase.");
                            Console.ReadKey();
                            break;
                        }
                    }
                }

            }
            else
            {
                Console.WriteLine("Insufficient Funds! Please feed money into the machine before making a purchase.");
                Console.ReadKey();
            }
        }
        

        // Audits Selection 3 from Purchase Menu.
        public void AuditSelection3 ()
        {
            string line = $"{DateTime.Now}   Give Change:   {changeForAudit:C}      $0.00";
            WriteLog(line);
        }


        // Audits Selection 1 from Purchase Menu.
        public void AuditSelection1()
        {
            string line = $"{DateTime.Now}   Feed Money:    {billsEnteredForAudit:C}     {Balance:C}";
            WriteLog(line);
        }


        // Method to print out sound after selection 3 in Purchase Menu. This is only shown when a user is done and "Consumes" what they purchased.
        public void PrintOutSoundForEachPurchase()
        {
            foreach (Stock itemPurchased in RemovedItems)
            {
                if (itemPurchased.Product.Category == "Chip")
                {
                    Console.WriteLine("Crunch Crunch, Yum!");
                }
                else if (itemPurchased.Product.Category == "Candy")
                {
                    Console.WriteLine("Munch Munch, Yum!");
                }
                else if (itemPurchased.Product.Category == "Drink")
                {
                    Console.WriteLine("Glug Glug, Yum!");
                }
                else if (itemPurchased.Product.Category == "Gum")
                {
                    Console.WriteLine("Chew Chew, Yum!");
                }
            }
            Console.ReadKey();

            Balance = 0;
        }

    }
}
