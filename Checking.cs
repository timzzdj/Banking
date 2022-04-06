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
        public static double checkings_balance;
        public static double checkings_debits;
        public static double checkings_credits;
        public static double checkings_interest;
        // Constructors
        public Checking() { }
        public Checking(double checkings_bal, double checkings_deb, double checkings_cred)
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
        public override double StartingBalance { get => checkings_balance - EndingBalance; }
        public override double EndingBalance { get => (checkings_balance + checkings_credits - checkings_debits) * checkings_interest; }
        public sealed override string AccountType => $"Checkings";
        // Methods
        public static double CheckingsDeposit(double p_amount_deposited)
        {
            checkings_balance += p_amount_deposited;
            return checkings_balance;
        }
        public static double CheckingsWithdrawal(double p_amount_withdrew)
        {
            checkings_balance -= p_amount_withdrew;
            return checkings_balance;
        }        
        public static void CheckingsEndCycle()
        {
            checkings_balance += (checkings_balance + checkings_credits - checkings_debits) * checkings_interest;
            checkings_credits = 0.0f;
            checkings_debits = 0.0f;
        }
        public override string ToString()
        {
            return $"Account Number: {AccountNumber}\nInterest Rate: {String.Format("{0:P2}", AnnualPercentRate)}\nStarting Balance: ${Math.Round(StartingBalance, 2)}" +
                   $"\nEnding Balance: ${Math.Round(EndingBalance + StartingBalance, 2)}\nChecking Debits: ${checkings_debits}\nChecking Credits: ${checkings_credits}";
        }
    }
}
