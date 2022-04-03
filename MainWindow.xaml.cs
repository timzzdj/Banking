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
        Customer new_customer = new Customer("Timothy de Jesus", "250 Brent Ln. Pensacola, FL", 1234567890);
        public MainWindow()
        {
            InitializeComponent();
            loadBank();
            loadCustomers();
            loadAccounts();
        }
        private void loadBank()
        {
            txtBankDetails.Text = new_bank.ToString();
        }
        private void loadCustomers()
        {
            Bank.AddCustomer(new_customer);

            for (int x = 0; x < Bank.customerList.Count; x++)
            {
                cmbCustomerList.Items.Add(Bank.customerList[x].customer_name);
            }
        }

        private void loadAccounts()
        {
            Account new_checkings  = new Checking();
            Account new_savings    = new Savings();
            Account new_loan       = new Loan();
            Account new_retirement = new Retirement();
            Customer.AddAccount(new_checkings);
            Customer.AddAccount(new_savings);
            Customer.AddAccount(new_loan);
            Customer.AddAccount(new_retirement);
            txtAccountDetails.Text = new_retirement.ToString();
        }

        private void cmbCustomerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(cmbCustomerList.SelectedIndex)
            {
                case -1:
                    txtCustomerDetails.Text = string.Empty;
                    break;
                case 0:
                    txtCustomerDetails.Text = new_customer.ToString();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Item selected Out of Range!");
            }
        }

        private void cmbAccountType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbAccountType.SelectedIndex > -1)
            {
                txtInputAmount.IsEnabled = true;

                switch(cmbAccountType.SelectedIndex)
                {
                    case -1:
                        txtAccountDetails.Text = string.Empty;
                        break;
                }
            }
        }
    }
}
