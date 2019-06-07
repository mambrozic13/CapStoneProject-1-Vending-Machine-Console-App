using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Change
    {
        

        public Change(int quarters, int dimes, int nickels)
        {
            this.Quarters = quarters;
            this.Dimes = dimes;
            this.Nickels = nickels;
        }

        int Quarters { get; set; }
        int Dimes { get; set; }
        int Nickels { get; set; }


    }
}
