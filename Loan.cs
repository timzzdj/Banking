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
        private float loan_principle;
        private float loan_payments;
        private float loan_interest;

        // Constructors
        public Loan() { }
        public Loan(float loan_prin, float loan_pay, float annual_percent_rate, int acc_num) : base(annual_percent_rate, acc_num)
        {
            loan_principle = loan_prin;
            loan_payments = loan_pay;
            loan_interest = 0.05f / 12;
        }
        // Properties
        public float LoanPrinciple { get => loan_principle;}
        public override float StartingBalance { get => loan_principle; }
        public override float EndingBalance { get => (loan_principle - loan_payments) * loan_interest; }
        public sealed override string AccountType => $"Loan";
        // Methods
        public float PayLoan(float p_amount_paid)
        {
            if (loan_principle > 0.0f)
            {
                loan_payments += p_amount_paid;
            }
            else
            {
                throw new ArgumentException("Loan owed is less than payment!");
            }
            return loan_payments;
        }
        public void LoanEndCycle()
        {
            loan_principle += (loan_principle - loan_payments) * (loan_interest / 12);
            loan_payments = 0.0f;
        }
        public override string ToString()
        {
            return $"Account Number: {AccountNumber}\nInterest Rate: {String.Format("{0:P2}", loan_interest)}" +
                   $"\nStarting Balance: ${Math.Floor(StartingBalance - EndingBalance)}\nEnding Balance: ${Math.Floor(EndingBalance + StartingBalance)}" +
                   $"\nLoan Principle: ${Math.Floor(loan_principle)}" + $"\nLoan Payments: ${Math.Floor(loan_payments)}";
        }
    }
}
