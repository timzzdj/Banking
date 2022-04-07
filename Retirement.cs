using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project05
{
    internal class Retirement : Account 
    {
        // Fields
        private float retirement_balance;  // The retirement account's balance
        private float retirement_deposits; // The retirement account's deposits
        private float retirement_interest; // The retirement account's interest rate

        // Constructors
        public Retirement() { }
        public Retirement(float retirement_bal, float retirement_dep, float annual_percent_rate, int acc_num) : base(annual_percent_rate, acc_num)
        {
            retirement_balance = retirement_bal;
            retirement_deposits = retirement_dep;
            retirement_interest = AnnualPercentRate / 12;
        }
        // Properties
        public float RetirementBalance { get => retirement_balance; }
        public override float StartingBalance { get => retirement_balance; }
        public override float EndingBalance { get => (retirement_deposits + retirement_balance) * retirement_interest; }
        public sealed override string AccountType => $"Retirement";
        //Methods
        /* Deposits an amount given by the user to the account */
        public float RetirementDeposit(float p_amount_deposited)
        {
            if(retirement_balance >= -1.0f)
            {
                retirement_balance += p_amount_deposited;
            }
            else
            {
                throw new ArgumentException("Invalid Funds!");
            }
            return retirement_balance;
        }
        /* Ends the current account's cycle for the month */
        public void RetirementEndCycle()
        {
            retirement_balance += (retirement_deposits + retirement_balance) * retirement_interest;
            retirement_deposits = 0.0f;
        }
        public override string ToString()
        {
            return $"Account Number: {AccountNumber}\nInterest Rate: {String.Format("{0:P2}", AnnualPercentRate)}" +
                   $"\nStarting Balance: ${Math.Floor(StartingBalance)}\nEnding Balance: ${Math.Floor(EndingBalance + StartingBalance)}\nRetirement Balance: ${Math.Floor(retirement_balance)}";
        }
    }
}
