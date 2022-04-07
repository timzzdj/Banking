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
            new_checkings = new Checking(0.0f, 0.0f, 0.0f, 0.01f, 137243);
            new_savings = new Savings(0.0f, 0.0f, 0.0f, 0.05f, 137243);
            new_loan = new Loan(1000000.0f, 0.0f, 0.01f, 137243);
            new_retirement = new Retirement(0.0f, 0.0f, 0.5f, 137243);
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
                if (txtCycleChanges.Text == string.Empty)
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
                else 
                    MessageBox.Show("Please End Your Cycle First!", "Incomplete changes!");
            }            
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            if (txtInputAmount.Text != string.Empty)
            {
                if (cmbAccountType.SelectedIndex == 0)
                {
                    float start_checking_bal = new_checkings.CheckingsBalance;
                    float deposit_total = new_checkings.CheckingsDeposit(float.Parse(txtInputAmount.Text));

                    txtAccountDetails.Text = new_customer.AccountsLists[0].ToString();
                    txtCycleChanges.Text = $"Checkings Balance: ${Math.Floor(start_checking_bal)}\n\t\t  +\nDeposited Amount: ${txtInputAmount.Text}\nTotal Amount:\t   ${Math.Floor(deposit_total)}";
                }
                else if (cmbAccountType.SelectedIndex == 1)
                {
                    float start_saving_bal = new_savings.SavingsBalance;
                    float deposit_total = new_savings.SavingsDeposit(float.Parse(txtInputAmount.Text));

                    txtAccountDetails.Text = new_customer.AccountsLists[1].ToString();
                    txtCycleChanges.Text = $"Savings Balance:\t   ${Math.Floor(start_saving_bal)}\n\t\t  +\nDeposited Amount: ${txtInputAmount.Text}\nTotal Amount:\t   ${Math.Floor(deposit_total)}";
                }
                else if (cmbAccountType.SelectedIndex == 3)
                {
                    float start_retire_bal = new_retirement.RetirementBalance;
                    float deposit_total = new_retirement.RetirementDeposit(float.Parse(txtInputAmount.Text));

                    txtAccountDetails.Text = new_customer.AccountsLists[3].ToString();
                    txtCycleChanges.Text = $"Retirement Balance:${Math.Floor(start_retire_bal)}\n\t\t  +\nDeposited Amount: ${txtInputAmount.Text}\nTotal Amount:\t   ${Math.Floor(deposit_total)}";
                }
            }
            else
                txtCycleChanges.Text = $"No Amount To Deposit!";
        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            if (txtInputAmount.Text != string.Empty)
            {
                if (new_customer.AccountsLists[cmbAccountType.SelectedIndex].StartingBalance > 0.0f)
                {
                    if (cmbAccountType.SelectedIndex == 0)
                    {
                        float start_checking_bal = new_checkings.CheckingsBalance;
                        float withdraw_total = new_checkings.CheckingsWithdrawal(float.Parse(txtInputAmount.Text));

                        txtAccountDetails.Text = new_customer.AccountsLists[0].ToString();
                        txtCycleChanges.Text = $"Checkings Balance: ${Math.Floor(start_checking_bal)}\n\t\t  -\nWithdraw Amount: ${txtInputAmount.Text}\nTotal Amount:\t   ${Math.Floor(withdraw_total)}";
                    }
                    else if (cmbAccountType.SelectedIndex == 1)
                    {
                        float start_saving_bal = new_savings.SavingsBalance;
                        float withdraw_total = new_savings.SavingsWithdrawal(float.Parse(txtInputAmount.Text));

                        txtAccountDetails.Text = new_customer.AccountsLists[1].ToString();
                        txtCycleChanges.Text = $"Savings Balance:\t   ${Math.Floor(start_saving_bal)}\n\t\t  -\nWithdraw Amount: ${txtInputAmount.Text}\nTotal Amount:\t   ${Math.Floor(withdraw_total)}";
                    }
                }
                else
                {
                    txtCycleChanges.Text = string.Empty;
                    txtCycleChanges.Text = $"Insufficient Funds!";
                }
            }
            else
                txtCycleChanges.Text = $"No To Amount Withdrew!";
        }

        private void btnPay_Click(object sender, RoutedEventArgs e)
        {
            if (txtInputAmount.Text != string.Empty)
            {
                if (new_customer.AccountsLists[2].StartingBalance > 0.0f)
                {
                    if (cmbAccountType.SelectedIndex == 2)
                    {
                        float start_loan_principle = new_loan.LoanPrinciple;
                        float payment_total = new_loan.PayLoan(float.Parse(txtInputAmount.Text));

                        txtAccountDetails.Text = new_customer.AccountsLists[2].ToString();
                        txtCycleChanges.Text = $"Loan Principle:\t  ${Math.Floor(start_loan_principle)}\n\t\t  -\nAmount Paid:\t  ${txtInputAmount.Text}\nTotal Amount:\t   ${Math.Floor(payment_total)}";
                    }
                }
                else
                    txtCycleChanges.Text = $"Loan owed is less than payment!";
            }
            else
                txtCycleChanges.Text = $"No Amount To Pay Loan!";
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

        private void txtInputAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
