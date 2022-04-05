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

        // Constructors
        public Retirement() { }
        public Retirement(double retirement_bal, double retirement_dep)
        {
            retirement_balance = retirement_bal;
            retirement_deposits = retirement_dep;
        }
        // Properties
        public double RetirementBalance { get => retirement_balance; }

        //Methods
        public void RetirementDeposit(double p_amount_deposited)
        {
            retirement_deposits += p_amount_deposited;
        }
        public override double StartingBalance { get => 0.00f; }
        public override double EndingBalance { get; }
        public sealed override string AccountType => $"Retirement";
        public override string ToString()
        {
            return $"\tAccount Number: {AccountNumber}\n\tInterest Rate: {String.Format("{0:P2}", AnnualPercentRate)}\n\tStarting Balance: ${StartingBalance}\n\tEnding Balance: ${EndingBalance}\n\tRetirement Balance: ${retirement_balance}\n\tRetiremnet Deposits: ${retirement_deposits}";
        }
    }
}
