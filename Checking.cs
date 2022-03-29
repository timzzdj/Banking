using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project05
{
    internal class Checking : Account
    {
        // Fields
        private double checkings_balance;
        public double checkings_debits;
        public double checkings_credits;
        // Properties
        public double CheckingsBalance
        {
            get => checkings_balance;
            set => checkings_balance = value;
        }
        public double CheckingsDebits
        {
            get => checkings_debits;
            set => checkings_debits = value;
        }
        public double CheckingsCredits
        {
            get => checkings_credits;
            set => checkings_credits = value;
        }
        // Methods
        public void CheckingsDeposit(double p_amount_deposited)
        {
            checkings_balance += p_amount_deposited;
        }
        public void CheckingsWithdrawal(double p_amount_withdrawed)
        {
            checkings_balance -= p_amount_withdrawed;
        }
    }
}
