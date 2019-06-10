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
                    Console.Clear();
                    Vendomatic.DisplayVendingMachineItems();
                    Pause("");
                    
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
