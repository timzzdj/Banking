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
        private double checkings_debits;
        private double checkings_credits;
        private double checkings_interest;
        // Constructors
        public Checking() { }
        public Checking(double checkings_bal, double checkings_deb, double checkings_cred, double annual_percent_rate, int acc_num) : base(annual_percent_rate, acc_num)
        {
            checkings_balance = checkings_bal;
            checkings_debits = checkings_deb;
            checkings_credits = checkings_cred;
            checkings_interest = AnnualPercentRate / 12;
        } 
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
        public double CheckingInterests
        {
            get => AnnualPercentRate;
        }
        public int CheckingAccountNum
        {
            get => AccountNumber;
        }
        public override double StartingBalance { get => checkings_balance; }
        public override double EndingBalance { get => (checkings_balance + checkings_credits - checkings_debits) * checkings_interest; }
        public sealed override string AccountType => $"Checkings";
        // Methods
        public double CheckingsDeposit(double p_amount_deposited)
        {
            checkings_credits += p_amount_deposited;
            return checkings_credits;
        }
        public double CheckingsWithdrawal(double p_amount_withdrew)
        {
            checkings_debits += p_amount_withdrew;
            return checkings_debits;
        }        
        public void CheckingsEndCycle()
        {
            checkings_balance += (checkings_balance + checkings_credits - checkings_debits) * checkings_interest;
            //checkings_balance += (checkings_balance + checkings_credits - checkings_debits) * checkings_interest;
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
