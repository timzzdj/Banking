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
        
        public MainWindow()
        {
            InitializeComponent();
            btnExit_Bank.Visibility = Visibility.Hidden;
            btnEnterBank.Visibility = Visibility.Visible;
            btnReturnView.Visibility = Visibility.Hidden;
            loadCustomerView();
        }

        public void loadBank()
        {
            Bank new_bank = new Bank("Bank of Ruptcy", "888 Bank Blvd. Pensacola, FL.", 0987654321);
            txtBank_Name.Text = new_bank.ToString();
        }

        public void loadCustomers()
        {
            Customer new_customer = new Customer("Timothy de Jesus", "250 Brent Ln. Pensacola, Fl", 123456789);
            Bank.AddCustomer(new_customer);
            txtCustomer_Details.Text = new_customer.ToString();

            try
            {
                for (int x = 0; x <= Bank.customerList.Count - 1; x++)
                {
                    Button customer_button = new Button();
                    customer_button.Content = $"{Bank.customerList[x].customer_name}";
                    customer_button.Name = $"btnCustomerNew{x}";
                    customer_button.Visibility = Visibility.Visible;
                    customer_button.Click += new RoutedEventHandler(customer_button_Click);
                    grdCustomerButtons.Children.Add(customer_button);
                }
            }
            catch (ArgumentOutOfRangeException aRe)
            {
                throw new ArgumentOutOfRangeException("An error occurred, please exit the bank.", aRe);
            }
        }
        public void loadAccounts()
        {
            
        }

        protected void customer_button_Click(object sender, RoutedEventArgs e)
        {
            if (txtCustomer_Details.Visibility != Visibility.Visible)
            {
                txtCustomer_Details.Visibility = Visibility.Visible;
                btnShowAccounts.Visibility = Visibility.Visible;
            }
            else
            {
                txtCustomer_Details.Visibility = Visibility.Hidden;
                btnShowAccounts.Visibility = Visibility.Hidden;
            }
        }

        private void btnEnterBank_Click(object sender, RoutedEventArgs e)
        {
            btnEnterBank.Visibility = Visibility.Hidden;

            loadBank();
            loadCustomers();
            loadCustomerView();
        }

        private void btnExit_Bank_Click(object sender, RoutedEventArgs e)
        {
            btnEnterBank.Visibility = Visibility.Visible;
            btnReturnView.Visibility = Visibility.Hidden;
            loadCustomerView();
        }

        private void btnShowAccounts_Click(object sender, RoutedEventArgs e)
        {
            btnReturnView.Visibility = Visibility.Visible;
            loadCustomerView();
        }

        private void btnReturnView_Click(object sender, RoutedEventArgs e)
        {
            btnEnterBank.Visibility = Visibility.Hidden;
            btnReturnView.Visibility = Visibility.Hidden;
            loadCustomerView();
        }

        public void loadCustomerView()
        {
            if (btnEnterBank.Visibility == Visibility.Visible)
            {
                txtCustomer_Details.Visibility = Visibility.Hidden;
                txtBank_Name.Visibility = Visibility.Hidden;
                btnShowAccounts.Visibility = Visibility.Hidden;
                btnExit_Bank.Visibility = Visibility.Hidden;
                lblWelcome_msg1.Visibility = Visibility.Hidden;
                lblWelcome_msg2.Visibility = Visibility.Hidden;
                grdCustomerButtons.Visibility = Visibility.Hidden;
                grdAccountTabs.Visibility = Visibility.Hidden;
            }
            else if(btnReturnView.Visibility == Visibility.Visible)
            {
                txtCustomer_Details.Visibility = Visibility.Hidden;
                txtBank_Name.Visibility = Visibility.Hidden;
                btnShowAccounts.Visibility = Visibility.Hidden;
                grdCustomerButtons.Visibility = Visibility.Hidden;
                btnExit_Bank.Visibility = Visibility.Visible;
                grdAccountTabs.Visibility = Visibility.Visible;
            }
            else
            {
                txtBank_Name.Visibility = Visibility.Visible;
                btnExit_Bank.Visibility = Visibility.Visible;
                lblWelcome_msg1.Visibility = Visibility.Visible;
                lblWelcome_msg2.Visibility = Visibility.Visible;
                grdCustomerButtons.Visibility = Visibility.Visible;
                grdAccountTabs.Visibility = Visibility.Hidden;
            }
        }
    }
}
