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
        // Constructirs
        public Savings() { }
        public Savings(double savings_bal, double savings_deb, double savings_cred)
        {
            savings_balance = savings_bal;
            savings_debits = savings_deb;
            savings_credits = savings_cred;
        }
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
        public override double StartingBalance { get => 0.00f; }
        public override double EndingBalance { get; }
        public sealed override string AccountType => $"Savings";
        public override string ToString()
        {
            return $"\tAccount Number: {AccountNumber}\n\tInterest Rate: {String.Format("{0:P2}",AnnualPercentRate)}\n\tStarting Balance: ${StartingBalance}\n\tEnding Balance: ${EndingBalance}\n\tSavings Balance: ${savings_balance}\n\tSavings Debits: ${savings_debits}\n\tSavings Credits: ${savings_credits}";
        }
    }
}
