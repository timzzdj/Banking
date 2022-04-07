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
        private float checkings_balance;  // The checking's balance
        private float checkings_debits;   // The checking's debits
        private float checkings_credits;  // The checking's credits
        private float checkings_interest; // The checking's interest

        // Constructors
        public Checking() { }
        public Checking(float checkings_bal, float checkings_deb, float checkings_cred, float annual_percent_rate, int acc_num) : base(annual_percent_rate, acc_num)
        {
            checkings_balance = checkings_bal;
            checkings_debits = checkings_deb;
            checkings_credits = checkings_cred;
            checkings_interest = AnnualPercentRate / 12;
        } 
        // Properties
        public float CheckingsBalance
        {
            get => checkings_balance;
            set => checkings_balance = value;
        }
        public float CheckingsDebits
        {
            get => checkings_debits;
            set => checkings_debits = value;
        }
        public float CheckingsCredits
        {
            get => checkings_credits;
            set => checkings_credits = value;
        }        
        public float CheckingInterests
        {
            get => AnnualPercentRate;
        }
        public int CheckingAccountNum
        {
            get => AccountNumber;
        }
        public override float StartingBalance { get => checkings_balance; }
        public override float EndingBalance { get => (checkings_balance + checkings_credits - checkings_debits) * checkings_interest; }
        public sealed override string AccountType => $"Checkings";

        // Methods
        /* Deposits an amount given by the user to the account */
        public float CheckingsDeposit(float p_amount_deposited)
        {
            if (checkings_credits >= -1.0f)
            {
                checkings_credits += p_amount_deposited;
            }
            else
            {
                throw new ArgumentException("Invalid Funds!");
            }
            return checkings_credits;
        }
        /* Withdraws an amount given by the user to the account */
        public float CheckingsWithdrawal(float p_amount_withdrew)
        {
            if (checkings_balance >= 0.0f)
            {
                checkings_debits += p_amount_withdrew;
            }
            else
            {
                throw new ArgumentException("Insufficient Funds!");
            }
            
            return checkings_debits;
        }
        /* Ends the current account's cycle for the month */
        public void CheckingsEndCycle()
        {
            checkings_balance += (checkings_balance + checkings_credits - checkings_debits) * checkings_interest;
            checkings_credits = 0.0f;
            checkings_debits = 0.0f;
        }
        public override string ToString()
        {
            return $"Account Number: {AccountNumber}\nInterest Rate: {String.Format("{0:P2}", AnnualPercentRate)}\nStarting Balance: ${Math.Floor(StartingBalance)}" +
                   $"\nEnding Balance: ${Math.Floor(EndingBalance + StartingBalance)}\nChecking Debits: ${checkings_debits}\nChecking Credits: ${checkings_credits}";
        }
    }
}
