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

        // Fields
        public static double account_number;
        //private string account_type;
        private double annual_percentage_rate;

        // Constructor
        protected Account() { }
        protected Account(double annual_percent_rate, double acc_num)
        {
            account_number = acc_num;
           // account_type = acc_type;
            annual_percentage_rate = annual_percent_rate;
        }
        public double AccountNumber
        {
            get => account_number = 112334566789;            
        }
        public double AnnualPercentRate
        {
            get => annual_percentage_rate = 0.05f;
        }
        public abstract double StartingBalance { get; }
        public abstract double EndingBalance { get; }
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
        public override string ToString()
        {
            return $"\t--Account Information--\nAccount Number: {account_number}";
        }
    }
}
