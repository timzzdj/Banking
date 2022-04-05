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
        // Constructors
        public Checking() { }
        public Checking(double checkings_bal, double checkings_deb, double checkings_cred)
        {
            checkings_balance = checkings_bal;
            checkings_debits = checkings_deb;
            checkings_credits = checkings_cred;
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
        // Methods
        public void CheckingsDeposit(double p_amount_deposited)
        {
            checkings_balance += p_amount_deposited;
        }
        public void CheckingsWithdrawal(double p_amount_withdrawed)
        {
            checkings_balance -= p_amount_withdrawed;
        }
        public override double StartingBalance { get => 0.00f; }
        public override double EndingBalance { get; }
        public sealed override string AccountType => $"Checkings";
        public override string ToString()
        {
            return $"\tAccount Number: {AccountNumber}\n\tInterest Rate: {Math.Round(AnnualPercentRate, 2)}%\n\tStarting Balance: ${StartingBalance}\n\tEndling Balance: ${EndingBalance}\n\tChecking Balance: ${checkings_balance}\n\tChecking Debits: ${checkings_debits}\n\tChecking Credits: ${checkings_credits}";
        }
    }
}
