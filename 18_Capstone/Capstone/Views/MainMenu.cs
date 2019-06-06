﻿using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;


namespace Capstone.Views
{
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    public class MainMenu : CLIMenu
    {
        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public MainMenu(VendingMachine vm) : base(vm)
        {
            this.Title = "*** Main Menu ***";
            this.menuOptions.Add("1", "Display Vending Machine Items");
            this.menuOptions.Add("2", "Purchase");
            this.menuOptions.Add("Q", "Quit");
        }

        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            switch (choice)
            {
                case "1":

                    foreach (Stock item in Vendomatic.StockList)
                    {
                        Console.WriteLine($"{item.Location} Name:{item.Product.Name} Price:{item.Product.Price} Quantity: {item.Quantity}");
                    }
                    Pause("");
                    // This should show our dictionary of Products from Vending Machine class.
                    // be able to go up one menu when "Q"
                    return true;
                case "2":

                    PurchaseMenu Menu = new PurchaseMenu(Vendomatic);
                    Menu.Run();
                    Pause("");

                    
                    return true;
            }
            return true;
        }

    }
}
