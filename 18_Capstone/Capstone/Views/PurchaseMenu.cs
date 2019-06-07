using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.Classes;

namespace Capstone.Views
{
    public class PurchaseMenu : CLIMenu
    {
        List<Stock> RemovedItems = new List<Stock>();

        StreamWriter AuditLog = new StreamWriter("Log.txt");
    

        public PurchaseMenu(VendingMachine vm) : base(vm)
        {
            this.Title = "*** Purchase Menu ***";
            this.menuOptions.Add("1", "Feed Money");
            this.menuOptions.Add("2", "Select Product");
            this.menuOptions.Add("3", "Finish Transaction");
            this.menuOptions.Add("Q", "Quit");
        }
        
        protected override bool ExecuteSelection(string choice)
        {
            Console.WriteLine($"Your current balance {Vendomatic.Balance}");
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Please enter the amount to be deposited");
                    string moneyInput = Console.ReadLine();
                    Vendomatic.FeedMoney(decimal.Parse(moneyInput));
                    Console.WriteLine($"New Current Balance: {Vendomatic.Balance}");
                    string line = $"{DateTime.Now}   Feed Money:    ${moneyInput}.00     {Vendomatic.Balance:C}";
                    AuditLog.WriteLine(line);               
                    Pause("");

                    return true;
                case "2":
                    //Allows customer to select product
                    Console.WriteLine("What product would you like to purchase?");
                    string selectionInput = Console.ReadLine().ToUpper().Trim();

                    bool itemExists = false;
                    foreach (Stock item in Vendomatic.StockList)
                    {
                        if (selectionInput == item.Location)
                        {
                            itemExists = true;
                        }
                    }
                    if (!itemExists)
                    {
                        Console.WriteLine("Sorry the selection you made does not exist. Please check the list and Press enter to try again.");
                        Console.ReadKey();
                        break;
                    }

                    if (Vendomatic.Balance > 0)
                    {
                      foreach (Stock item in Vendomatic.StockList)
                        {
                            if (selectionInput == item.Location)
                            {
                                if (Vendomatic.Balance >= item.Product.Price)
                                {
                                    if (item.Quantity > 0)
                                    {
                                        Console.WriteLine($"You Selected: {item.Product.Name}");
                                        Console.ReadKey();
                                        Vendomatic.Balance -= item.Product.Price;
                                        item.Quantity -= 1;
                                        RemovedItems.Add(item);
                                         string line2 = $"{DateTime.Now}   {item.Product.Name} {selectionInput}   {Vendomatic.Balance}      ";
                                        AuditLog.WriteLine(line2);

                                        Pause("");
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
                        break;
                    }
                    

                    return true;

                case "3":
                    string line3 = $"{DateTime.Now}   Give Change:   {Vendomatic.Balance:C}      $0.00";
                    AuditLog.WriteLine(line3);

                    Vendomatic.ReturnChange(Vendomatic.Balance);
                    foreach(Stock itemPurchased in RemovedItems)
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
                        else if (itemPurchased.Product.Category == "gum")
                        {
                            Console.WriteLine("Chew Chew, Yum!");
                        }
                    }
                    Console.ReadKey();
                   
                    Vendomatic.Balance = 0;
                    AuditLog.Close();
                    return true;

            }           
            return true;
        }
        
    }
}
