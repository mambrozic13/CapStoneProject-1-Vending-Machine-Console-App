using System;
using System.Collections.Generic;
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
            Console.WriteLine($"Your current balance {Vendomatic.Balance}");
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Please enter the amount to be deposited");
                    string moneyInput = Console.ReadLine();
                    Vendomatic.FeedMoney(decimal.Parse(moneyInput));
                    Console.WriteLine($"{Vendomatic.Balance}");
                    Pause("");

                    return true;
                case "2":
                    
                    return true;
                case "3":

                    return true;

            }
            return true;
        }
        
    }
}
