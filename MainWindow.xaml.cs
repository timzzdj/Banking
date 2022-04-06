/*********************************************************************/
/* Author: Timothy de Jesus                                          */
/* Project #: 05                                                     */
/* Teacher: Mr. Michael Plain                                        */
/* Purpose: The purpose for this project is to use an abstract class */
/*          and inheritance to create various types of accounts that */
/*          inherit from a base account class.                       */
/*********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Bank new_bank = new Bank("Ruptcy", "888 Pigeons Blvd. Pensacola, FL", 0987654321);
        
        public MainWindow()
        {
            InitializeComponent();
            txtInputAmount.IsEnabled = false;
            btnDeposit.IsEnabled = false;
            btnWithdraw.IsEnabled = false;
            btnPay.IsEnabled = false;
            btnEndCycle.IsEnabled = false;
            // Load the Bank Details
            txtBankDetails.Text = new_bank.ToString();
            // Load the first customer details
            Customer new_customer = new Customer("Timothy de Jesus", "250 Brent Ln. Pensacola, FL", 1234567890);
            // Load first customer's accounts
            Account new_checkings = new Checking(0.00f, 0.0f, 0.0f);
            Customer.AddAccount(new_checkings);
            Account new_savings = new Savings(450.0f, 0.0f, 0.0f);
            Customer.AddAccount(new_savings);
            Account new_loan = new Loan(500.00f, 5000.00f);
            Customer.AddAccount(new_loan);
            Account new_retirement = new Retirement(1000.00f, 0.00f);
            Customer.AddAccount(new_retirement);
            // Add the first customers to the Bank
            Bank.AddCustomer(new_customer);

            // List each customer in a dropdown list
            for (int x = 0; x < Bank.customerList.Count; x++)
            {
                cmbCustomerList.Items.Add(Bank.customerList[x].customer_name);
            }
            // List each customer's accounts in a dropdown list
            for(int x = 0; x < Customer.accountList.Count; x++)
            {
                cmbAccountType.Items.Add(Customer.accountList[x].AccountType);
            }
        }
        private void cmbCustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbCustomerList.SelectedIndex == 0)
            {
                txtCustomerDetails.Text = Bank.customerList[0].ToString();
                cmbAccountType.IsEnabled = cmbCustomerList.SelectedIndex > -1;
            }
        }

        private void cmbAccountType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbAccountType.SelectedIndex > -1)
            {
                switch (cmbAccountType.SelectedIndex)
                {
                    case 0:
                        txtAccountDetails.Text = Customer.accountList[0].ToString();
                        btnDeposit.IsEnabled = true;
                        btnWithdraw.IsEnabled = true;
                        btnPay.IsEnabled = false;
                        btnEndCycle.IsEnabled = true;
                        break;
                    case 1:
                        txtAccountDetails.Text = Customer.accountList[1].ToString();
                        btnDeposit.IsEnabled = true;
                        btnWithdraw.IsEnabled = true;
                        btnPay.IsEnabled = false;
                        btnEndCycle.IsEnabled = true;
                        break;
                    case 2:
                        txtAccountDetails.Text = Customer.accountList[2].ToString();
                        btnDeposit.IsEnabled = false;
                        btnWithdraw.IsEnabled = true;
                        btnPay.IsEnabled = true;
                        btnEndCycle.IsEnabled = true;
                        break;
                    case 3:
                        txtAccountDetails.Text = Customer.accountList[3].ToString();
                        btnDeposit.IsEnabled = true;
                        btnWithdraw.IsEnabled = false;
                        btnPay.IsEnabled = false;
                        btnEndCycle.IsEnabled = true;
                        break;
                    default:
                        throw new Exception();
                }

                txtInputAmount.IsEnabled = true;
            }
            
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            
            if(txtCycleChanges.Text == string.Empty)
            {
                if(cmbAccountType.SelectedIndex == 0)
                {
                    double start_checking_bal = Checking.checkings_balance;
                    double deposit_total = Checking.CheckingsDeposit(double.Parse(txtInputAmount.Text));

                    txtCycleChanges.Text = $"Checkings Balance: ${Math.Round(start_checking_bal, 2)}\n\t\t  +\nDeposited Amount: ${txtInputAmount.Text}\nTotal Amount:\t   ${Math.Round(deposit_total, 2)}";
                }
                else if(cmbAccountType.SelectedIndex == 1)
                {
                    double start_saving_bal = Savings.savings_balance;
                    double deposit_total = Savings.SavingsDeposit(double.Parse(txtInputAmount.Text));

                    txtCycleChanges.Text = $"Savings Balance:\t   ${Math.Round(start_saving_bal, 2)}\n\t\t  +\nDeposited Amount: ${txtInputAmount.Text}\nTotal Amount:\t   ${Math.Round(deposit_total, 2)}";
                }
                else if(cmbAccountType.SelectedIndex == 3)
                {
                    double start_retire_bal = Retirement.retirement_balance;
                    double deposit_total = Retirement.RetirementDeposit(double.Parse(txtInputAmount.Text));

                    txtCycleChanges.Text = $"Retirement Balance:${Math.Round(start_retire_bal, 2)}\n\t\t  +\nDeposited Amount: ${txtInputAmount.Text}\nTotal Amount:\t   ${Math.Round(deposit_total, 2)}";
                }
            }
            else
            {
                MessageBox.Show("Please End your Cycle first!", "Incomplete Changes");
            }
        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            if (txtCycleChanges.Text == string.Empty)
            {
                if (cmbAccountType.SelectedIndex == 0)
                {
                    double start_checking_bal = Checking.checkings_balance;
                    double withdraw_total = Checking.CheckingsWithdrawal(double.Parse(txtInputAmount.Text));

                    txtCycleChanges.Text = $"Checkings Balance: ${Math.Round(start_checking_bal, 2)}\n\t\t  -\nWithdraw Amount: ${txtInputAmount.Text}\nTotal Amount:\t   ${Math.Round(withdraw_total, 2)}";
                }
                else if (cmbAccountType.SelectedIndex == 1)
                {
                    double start_saving_bal = Savings.savings_balance;
                    double withdraw_total = Savings.SavingsWithdrawal(double.Parse(txtInputAmount.Text));

                    txtCycleChanges.Text = $"Savings Balance:\t   ${Math.Round(start_saving_bal, 2)}\n\t\t  -\nWithdraw Amount: ${txtInputAmount.Text}\nTotal Amount:\t   ${Math.Round(withdraw_total, 2)}";
                }
                else if (cmbAccountType.SelectedIndex == 2)
                {
                    double start_loan_bal = Loan.loan_principle;
                    double withdraw_total = Loan.Loanwithdrawal(double.Parse(txtInputAmount.Text));

                    txtCycleChanges.Text = $"Loan Principle:\t  ${Math.Round(start_loan_bal, 2)}\n\t\t  -\nWithdraw Amount: ${txtInputAmount.Text}\nTotal Principle:\t   ${Math.Round(withdraw_total, 2)}";
                }
            }
            else
            {
                MessageBox.Show("Please End your Cycle first!", "Incomplete Changes");
            }
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            if(txtCycleChanges.Text == string.Empty)
            {
                if(cmbAccountType.SelectedIndex == 2)
                {
                    double start_loan_pay = Loan.loan_payments;
                    double payment_total = Loan.LoanPayments(double.Parse(txtInputAmount.Text));

                    txtCycleChanges.Text = $"Loan Payments:\t  ${Math.Round(start_loan_pay, 2)}\n\t\t  -\nAmount Paid:\t  ${txtInputAmount.Text}\nTotal Amount:\t   ${Math.Round(payment_total, 2)}";
                }
            }
            else
            {
                MessageBox.Show("Please End your Cycle first!", "Incomplete Changes");
            }
        }

        private void btnEndCycle_Click(object sender, RoutedEventArgs e)
        {           
            txtCycleChanges.Text = string.Empty;

            switch (cmbAccountType.SelectedIndex)
            {
                case 0:
                    Checking.CheckingsEndCycle();
                    txtAccountDetails.Text = Customer.accountList[0].ToString();
                    break;
                case 1:
                    txtAccountDetails.Text = Customer.accountList[1].ToString();
                    break;
                case 2:
                    txtAccountDetails.Text = Customer.accountList[2].ToString();
                    break;
                case 3:
                    txtAccountDetails.Text = Customer.accountList[3].ToString();
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
