using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project05
{
    internal abstract class Account
    {
        // Constants
        public const double ANNUAL_RATE = 0.1225;

        // Fields
        private int account_number;
        private string account_type;
        private double annual_percentage_rate;
        // Constructor
        public Account() { }
        public Account(int acc_num, string acc_type, double annual_percent_rate)
        {
            account_number = acc_num;
            account_type = acc_type;
            annual_percentage_rate = annual_percent_rate;
        }
        public int AccountNumber
        {
            get => account_number++;            
        }
        public virtual string AccountType
        {
            get => "Bank Account";
        }
       // public abstract double StartingBalance { get; }
      //  public abstract double EndingBalance { get; }
      /*  public override string ToString()
        {
            return $"";
        } */
    }
}
