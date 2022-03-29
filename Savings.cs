using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project05
{
    internal class Savings : Account
    {
        // Fields
        private double savings_balance;
        public double savings_debits;
        public double savings_credits;
        // Properties
        public double SavingsBalance
        {
            get => savings_balance;
            set => savings_balance = value;
        }
        public double SavingsDebits
        {
            get => savings_debits;
            set => savings_debits = value;
        }
        public double SavingsCredits
        {
            get => savings_credits;
            set => savings_credits = value;
        }
        // Methods
        public void SavingsDeposit(double p_amount_deposited)
        {
            savings_balance += p_amount_deposited;
        }
        public void SavingsWithdrawal(double p_amount_withdrawed)
        {
            savings_balance -= p_amount_withdrawed;
        }
    }
}
