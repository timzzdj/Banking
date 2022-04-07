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
        private float savings_balance;  // The saving's balance
        private float savings_debits;   // The saving's debits
        private float savings_credits;  // The saving's credits
        private float savings_interest; // The saving's interest

        // Constructirs
        public Savings() { }
        public Savings(float savings_bal, float savings_deb, float savings_cred, float annual_percent_rate, int acc_num) : base(annual_percent_rate,acc_num)
        {
            savings_balance = savings_bal;
            savings_debits = savings_deb;
            savings_credits = savings_cred;
            savings_interest = AnnualPercentRate / 12;
        }
        // Properties
        public float SavingsBalance
        {
            get => savings_balance;
            set => savings_balance = value;
        }
        public float SavingsDebits
        {
            get => savings_debits;
            set => savings_debits = value;
        }
        public float SavingsCredits
        {
            get => savings_credits;
            set => savings_credits = value;
        }
        public override float StartingBalance { get => savings_balance; }
        public override float EndingBalance { get => (savings_balance + savings_credits - savings_debits) * savings_interest; }
        public sealed override string AccountType => $"Savings";
        // Methods
        /* Deposits an amount given by the user to the account */
        public float SavingsDeposit(float p_amount_deposited)
        {
            if (savings_credits >= -1.0f)
            {
                savings_credits += p_amount_deposited;
            }
            else
            {
                throw new ArgumentException("Invalid Funds!");
            }
            return savings_credits;
        }
        /* Withdraws an amount given by the user to the account */
        public float SavingsWithdrawal(float p_amount_withdrew)
        {
            if(savings_balance >= 0.0f)
            {
                savings_debits += p_amount_withdrew;
            }         
            else
            {
                throw new ArgumentException("Insufficient Funds!");
            }
            return savings_debits;
        }
        /* Ends the current account's cycle for the month */
        public void SavingsEndCycle()
        {
            savings_balance += (savings_balance + savings_credits - savings_debits) * savings_interest;
            savings_credits = 0.0f;
            savings_debits = 0.0f;
        }
        public override string ToString()
        {
            return $"Account Number: {AccountNumber}\nInterest Rate: {String.Format("{0:P2}", AnnualPercentRate)}\nStarting Balance: ${Math.Floor(StartingBalance)}" +
                   $"\nEnding Balance: ${Math.Floor(EndingBalance + StartingBalance)}\nSavings Debits: ${savings_debits}\nSavings Credits: ${savings_credits}";
        }
    }
}
