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
        private float annual_percent_yield;

        // Constructor
        protected Account() { }
        protected Account(float annual_percent_rate, int acc_num)
        {
            account_number = acc_num;
            annual_percent_yield = annual_percent_rate;
        }
        public int AccountNumber
        {
            get => account_number;            
        }
        public float AnnualPercentRate
        {
            get => annual_percent_yield = 0.01f;
        }
        public abstract float StartingBalance { get; }
        public abstract float EndingBalance { get; }
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
