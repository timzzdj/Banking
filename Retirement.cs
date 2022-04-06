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
        private double retirement_balance;
        private double retirement_deposits;
        private double retirement_interest;

        // Constructors
        public Retirement() { }
        public Retirement(double retirement_bal, double retirement_dep, double annual_percent_rate, int acc_num) : base(annual_percent_rate, acc_num)
        {
            retirement_balance = retirement_bal;
            retirement_deposits = retirement_dep;
            retirement_interest = AnnualPercentRate / 12;
        }
        // Properties
        public double RetirementBalance { get => retirement_balance; }
        public override double StartingBalance { get => retirement_balance; }
        public override double EndingBalance { get => (retirement_deposits + retirement_balance) * retirement_interest; }
        public sealed override string AccountType => $"Retirement";
        //Methods
        public double RetirementDeposit(double p_amount_deposited)
        {
            retirement_balance += p_amount_deposited;
            return retirement_balance;
        }
        public void RetirementEndCycle()
        {
            retirement_balance += (retirement_deposits + retirement_balance) * retirement_interest;
            retirement_deposits = 0.0f;
        }
        public override string ToString()
        {
            return $"Account Number: {AccountNumber}\nInterest Rate: {String.Format("{0:P2}", AnnualPercentRate)}" +
                   $"\nStarting Balance: ${Math.Round(StartingBalance, 2)}\nEnding Balance: ${Math.Round(EndingBalance + StartingBalance, 2)}\nRetirement Balance: ${Math.Round(retirement_balance, 2)}";
        }
    }
}
