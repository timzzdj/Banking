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
        private int account_number = 137243;
        //private string account_type;
        private double annual_percent_yield;

        // Constructor
        protected Account() { }
        protected Account(double annual_percent_rate, int acc_num)
        {
            account_number = acc_num;
            annual_percent_yield = annual_percent_rate;
        }
        public int AccountNumber
        {
            get => account_number;            
        }
        public double AnnualPercentRate
        {
            get => annual_percent_yield = 0.01f;
        }
        public abstract double StartingBalance { get; }
        public abstract double EndingBalance { get; }
        public virtual string AccountType
        {
            get => "Bank Account";
        }
        public override string ToString()
        {
            return $"\t--Account Information--\nAccount Number: {account_number}";
        }
    }
}
