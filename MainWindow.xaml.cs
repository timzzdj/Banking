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
            loadCustomerButtons();
        }

        private void btnEnterBank_Click(object sender, RoutedEventArgs e)
        {
            loadCustomerAccounts();
            txtCustomer_Details.Visibility = Visibility.Visible;
            btnExit_Bank.Visibility = Visibility.Visible;
            btnEnterBank.Visibility = Visibility.Hidden;
        }
        public void loadCustomerAccounts()
        {
            var new_customer = new List<Customer>
            {
                new Customer("Timothy de Jesus", "250 Brent Ln. Pensacola, Fl", 123456789)
            };
            txtCustomer_Details.Text = new_customer[0].ToString();
        }
        public void loadBank()
        {
            var new_bank = new List<Bank>
            {
                new Bank("Bank of Ruptcy", "888 Bank Blvd. Pensacola, FL.", 0987654321)
            };
        }

        private void btnExit_Bank_Click(object sender, RoutedEventArgs e)
        {
            txtCustomer_Details.Visibility = Visibility.Hidden;
            btnExit_Bank.Visibility = Visibility.Hidden;
            btnEnterBank.Visibility = Visibility.Visible;
        }
        public void loadCustomerButtons()
        {
            txtCustomer_Details.Visibility = Visibility.Hidden;
            btnExit_Bank.Visibility = Visibility.Hidden;
            btnEnterBank.Visibility = Visibility.Visible;
        }
    }
}
