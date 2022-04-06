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
        private double savings_debits;
        private double savings_credits;
        private double savings_interest;
        // Constructirs
        public Savings() { }
        public Savings(double savings_bal, double savings_deb, double savings_cred, double annual_percent_rate, int acc_num) : base(annual_percent_rate,acc_num)
        {
            savings_balance = savings_bal;
            savings_debits = savings_deb;
            savings_credits = savings_cred;
            savings_interest = AnnualPercentRate / 12;
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
        public override double StartingBalance { get => savings_balance; }
        public override double EndingBalance { get => (savings_balance + savings_credits - savings_debits) * savings_interest; }
        public sealed override string AccountType => $"Savings";
        // Methods
        public double SavingsDeposit(double p_amount_deposited)
        {
            savings_credits += p_amount_deposited;
            return savings_credits;
        }
        public double SavingsWithdrawal(double p_amount_withdrew)
        {
            savings_debits += p_amount_withdrew;
            return savings_debits;
        }
        public void SavingsEndCycle()
        {
            savings_balance += (savings_balance + savings_credits - savings_debits) * savings_interest;
            savings_credits = 0.0f;
            savings_debits = 0.0f;
        }
        public override string ToString()
        {
            return $"Account Number: {AccountNumber}\nInterest Rate: {String.Format("{0:P2}", AnnualPercentRate)}\nStarting Balance: ${Math.Round(StartingBalance, 2)}" +
                   $"\nEnding Balance: ${Math.Round(EndingBalance + StartingBalance, 2)}\nSavings Debits: ${savings_debits}\nSavings Credits: ${savings_credits}";
        }
    }
}
