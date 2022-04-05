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
        public static double retirement_balance;
        public static double retirement_deposits;

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
        public static double RetirementDeposit(double p_amount_deposited)
        {
            retirement_balance += p_amount_deposited;
            return retirement_balance;
        }
        public override double StartingBalance { get => 0.00f; }
        public override double EndingBalance { get; }
        public sealed override string AccountType => $"Retirement";
        public override string ToString()
        {
            return $"Account Number: {AccountNumber}\nInterest Rate: {String.Format("{0:P2}", AnnualPercentRate)}\nStarting Balance: ${StartingBalance}\nEnding Balance: ${EndingBalance}\nRetirement Balance: ${retirement_balance}\nRetiremnet Deposits: ${retirement_deposits}";
        }
    }
}
