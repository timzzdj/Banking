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
        
        // Properties
        public double RetirementBalance { get => retirement_balance; }

        //Methods
        public void RetirementDeposit(double p_amount_deposited)
        {
            retirement_deposits += p_amount_deposited;
        }
        public override double StartingBalance { get => 1000.00; }
        public override double EndingBalance { get; }
        public sealed override string AccountType => $"Retirement";
        public override string ToString()
        {
            return $"\tStarting Balance: ${StartingBalance}\n\tEnding Balance: ${EndingBalance}\n\tRetirement Balance: ${retirement_balance}\n\tRetiremnet Deposits: ${retirement_deposits}";
        }
    }
}
