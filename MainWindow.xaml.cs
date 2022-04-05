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
            Account new_checkings = new Checking(500.00f, 0.0f, 0.0f);
            Customer.AddAccount(new_checkings);
            Account new_savings = new Savings(450.0f, 0.0f, 0.0f);
            Customer.AddAccount(new_savings);
            Account new_loan = new Loan(0.00f, 5000.00f);
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

                txtInputAmount.IsEnabled = true;
            }
            
        }

        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            if(cmbCustomerList.SelectedIndex > -1)
            {

            }
        }
    }
}
