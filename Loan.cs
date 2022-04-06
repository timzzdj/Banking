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
        private double loan_interest;

        // Constructors
        public Loan() { }
        public Loan(double loan_prin, double loan_pay, double annual_percent_rate, int acc_num) : base(annual_percent_rate, acc_num)
        {
            loan_principle = loan_prin;
            loan_payments = loan_pay;
            loan_interest = 0.05 / 12;
        }
        // Properties
        public double LoanPrinciple { get => loan_principle;}
        public override double StartingBalance { get => loan_principle; }
        public override double EndingBalance { get => (loan_principle - loan_payments) * loan_interest; }
        public sealed override string AccountType => $"Loan";
        // Methods
        public double LoanPayments(double p_amount_paid)
        {
            loan_principle -= p_amount_paid;
            return loan_principle;
        }
        public void LoanEndCycle()
        {
            loan_principle += (loan_principle - loan_payments) * (loan_interest / 12);
            loan_payments = 0.0f;
        }
        public override string ToString()
        {
            return $"Account Number: {AccountNumber}\nInterest Rate: {String.Format("{0:P2}", loan_interest)}" +
                   $"\nStarting Balance: ${Math.Round(StartingBalance - EndingBalance, 2)}\nEnding Balance: ${Math.Round(EndingBalance + StartingBalance, 2)}" +
                   $"\nLoan Principle: ${Math.Round(loan_principle, 2)}";
        }
    }
}
