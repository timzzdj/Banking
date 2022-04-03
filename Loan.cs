using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project05
{
    internal class Loan : Account 
    {
        // Fields
        private double loan_principle;
        private double loan_payments;

        // Properties
        public double LoanPrinciple { get => loan_principle;}

        // Methods
        public void LoanPayments(double p_amount_paid)
        {
            loan_payments -= p_amount_paid;
        }
        public override double StartingBalance { get => 10000.00; }
        public override double EndingBalance { get;}
        public sealed override string AccountType => $"Loan";
        public override string ToString()
        {
            return $"\tStarting Balance: ${StartingBalance}\n\tEnding Balance: ${EndingBalance}\n\tLoan Principle: ${loan_principle}\n\tLoan Payments: ${loan_payments}";
        }
    }
}
