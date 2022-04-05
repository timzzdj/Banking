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
        public static double loan_principle;
        public static double loan_payments;

        // Constructors
        public Loan() { }
        public Loan(double loan_prin, double loan_pay)
        {
            loan_principle = loan_prin;
            loan_payments = loan_pay;
        }
        // Properties
        public double LoanPrinciple { get => loan_principle;}

        // Methods
        public static double Loanwithdrawal(double p_amount_withdrew)
        {
            loan_principle -= p_amount_withdrew;
            return loan_principle;
        }
        public static double LoanPayments(double p_amount_paid)
        {
            loan_payments -= p_amount_paid;
            loan_principle += p_amount_paid;
            return loan_payments;
        }
        public override double StartingBalance { get => 0.00f; }
        public override double EndingBalance { get;}
        public sealed override string AccountType => $"Loan";
        public override string ToString()
        {
            return $"\tAccount Number: {AccountNumber}\n\tInterest Rate: {String.Format("{0:P2}", AnnualPercentRate)}\n\tStarting Balance: ${StartingBalance}\n\tEnding Balance: ${EndingBalance}\n\tLoan Principle: ${loan_principle}\n\tLoan Payments: ${loan_payments}";
        }
    }
}
