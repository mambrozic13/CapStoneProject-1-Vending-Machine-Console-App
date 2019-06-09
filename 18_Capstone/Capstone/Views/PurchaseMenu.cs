using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.Classes;

namespace Capstone.Views
{
    public class PurchaseMenu : CLIMenu
    {
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
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine($"Your current balance is {Vendomatic.Balance:C}");
                    Console.WriteLine("Please enter bills in the amount of 1.00, 2.00, 5.00, or 10.00");
                    string moneyInput = Console.ReadLine();
                    Vendomatic.FeedMoney(decimal.Parse(moneyInput));
                    Vendomatic.AuditSelection1();
                    Pause("");
                    return true;
                case "2":
                    Console.Clear();
                    Console.WriteLine($"Your current balance is {Vendomatic.Balance:C}");
                    Console.WriteLine("Please enter the location of the product you would like to purchase: ");
                    string selectionInput = Console.ReadLine().ToUpper().Trim();
                    Vendomatic.SelectProduct(selectionInput);
                    return true;

                case "3":
                    Console.Clear();
                    Console.WriteLine($"Your current balance to be returned in change is: {Vendomatic.Balance:C}");
                    Vendomatic.ReturnChange(Vendomatic.Balance);
                    Vendomatic.PrintOutSoundForEachPurchase(Vendomatic.RemovedItems);
                    Console.WriteLine();
                    Console.WriteLine("Please Press Enter to Return to Purchase Menu...");
                    Console.ReadKey();
                    Vendomatic.AuditSelection3();
                    return true;

            }           
            return true;
        }
        
    }
}
