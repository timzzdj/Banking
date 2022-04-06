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
        Customer new_customer = new Customer("Timothy de Jesus", "250 Brent Ln. Pensacola, FL", "+1 (234)-567-8901");
        Checking new_checkings;
        Savings new_savings;
        Loan new_loan;
        Retirement new_retirement;
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
            new_bank.AddCustomer(new_customer);
            // Load the first customer details
            new_checkings = new Checking(0.0, 0.0, 0.0, 0.01, 137243);
            new_savings = new Savings(0.0, 0.0, 0.0, 0.05, 137243);
            new_loan = new Loan(0.0, 0.0, 0.01, 137243);
            new_retirement = new Retirement(0.0, 0.0, 0.5, 137243);
            //new_savings
            // Load first customer's accounts
            new_customer.AddAccount(new_checkings);
            new_customer.AddAccount(new_savings);
            new_customer.AddAccount(new_loan);
            new_customer.AddAccount(new_retirement);
            // Add the first customers to the Bank
            loadCustomerLists();
            loadAccountLists();
            
        }
        public void loadCustomerLists()
        {
            // List each customer in a dropdown list
            for (int x = 0; x < new_bank.CustomerLists.Count; x++)
            {
                cmbCustomerList.Items.Add(new_bank.CustomerLists[x].CustomerName);
            }
        }
        public void loadAccountLists()
        {
            foreach (Account accounts in new_customer.AccountsLists)
            {
                cmbAccountType.Items.Add(accounts.AccountType);
            }
        }
        private void cmbCustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbCustomerList.SelectedIndex == 0)
            {
                txtCustomerDetails.Text = new_bank.CustomerLists[0].ToString();
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
                        txtAccountDetails.Text = new_customer.AccountsLists[0].ToString();
                        btnDeposit.IsEnabled = true;
                        btnWithdraw.IsEnabled = true;
                        btnPay.IsEnabled = false;
                        btnEndCycle.IsEnabled = true;
                        break;
                    case 1:
                        txtAccountDetails.Text = new_customer.AccountsLists[1].ToString();
                        btnDeposit.IsEnabled = true;
                        btnWithdraw.IsEnabled = true;
                        btnPay.IsEnabled = false;
                        btnEndCycle.IsEnabled = true;
                        break;
                    case 2:
                        txtAccountDetails.Text = new_customer.AccountsLists[2].ToString();
                        btnDeposit.IsEnabled = false;
                        btnWithdraw.IsEnabled = false;
                        btnPay.IsEnabled = true;
                        btnEndCycle.IsEnabled = true;
                        break;
                    case 3:
                        txtAccountDetails.Text = new_customer.AccountsLists[3].ToString();
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
                    double start_checking_bal = new_checkings.CheckingsBalance;
                    double deposit_total = new_checkings.CheckingsDeposit(double.Parse(txtInputAmount.Text));

                    txtCycleChanges.Text = $"Checkings Balance: ${Math.Round(start_checking_bal, 2)}\n\t\t  +\nDeposited Amount: ${txtInputAmount.Text}\nTotal Amount:\t   ${Math.Round(deposit_total, 2)}";
                }
                else if(cmbAccountType.SelectedIndex == 1)
                {
                    double start_saving_bal = new_savings.SavingsBalance;
                    double deposit_total = new_savings.SavingsDeposit(double.Parse(txtInputAmount.Text));

                    txtCycleChanges.Text = $"Savings Balance:\t   ${Math.Round(start_saving_bal, 2)}\n\t\t  +\nDeposited Amount: ${txtInputAmount.Text}\nTotal Amount:\t   ${Math.Round(deposit_total, 2)}";
                }
                else if(cmbAccountType.SelectedIndex == 3)
                {
                    double start_retire_bal = new_retirement.RetirementBalance;
                    double deposit_total = new_retirement.RetirementDeposit(double.Parse(txtInputAmount.Text));

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
                    double start_checking_bal = new_checkings.CheckingsBalance;
                    double withdraw_total = new_checkings.CheckingsWithdrawal(double.Parse(txtInputAmount.Text));

                    txtCycleChanges.Text = $"Checkings Balance: ${Math.Floor(start_checking_bal)}\n\t\t  -\nWithdraw Amount: ${txtInputAmount.Text}\nTotal Amount:\t   ${Math.Round(withdraw_total, 2)}";
                }
                else if (cmbAccountType.SelectedIndex == 1)
                {
                    double start_saving_bal = new_savings.SavingsBalance;
                    double withdraw_total = new_savings.SavingsWithdrawal(double.Parse(txtInputAmount.Text));

                    txtCycleChanges.Text = $"Savings Balance:\t   ${Math.Floor(start_saving_bal)}\n\t\t  -\nWithdraw Amount: ${txtInputAmount.Text}\nTotal Amount:\t   ${Math.Round(withdraw_total, 2)}";
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
                    double start_loan_principle = new_loan.LoanPrinciple;
                    double payment_total = new_loan.LoanPayments(double.Parse(txtInputAmount.Text));

                    txtCycleChanges.Text = $"Loan Principle:\t  ${Math.Round(start_loan_principle, 2)}\n\t\t  -\nAmount Paid:\t  ${txtInputAmount.Text}\nTotal Amount:\t   ${Math.Round(payment_total, 2)}";
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
                    new_checkings.CheckingsEndCycle();
                    txtAccountDetails.Text = new_customer.AccountsLists[0].ToString();
                    break;
                case 1:
                    new_savings.SavingsEndCycle();
                    txtAccountDetails.Text = new_customer.AccountsLists[1].ToString();
                    break;
                case 2:
                    new_loan.LoanEndCycle();
                    txtAccountDetails.Text = new_customer.AccountsLists[2].ToString();
                    break;
                case 3:
                    new_retirement.RetirementEndCycle();
                    txtAccountDetails.Text = new_customer.AccountsLists[3].ToString();
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
