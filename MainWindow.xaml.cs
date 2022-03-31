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
            loadBank(); 
            loadCustomers();            
            txtBank_Name.Visibility = Visibility.Visible;
            btnExit_Bank.Visibility = Visibility.Visible;
            btnEnterBank.Visibility = Visibility.Hidden;
            lblWelcome_msg1.Visibility = Visibility.Visible;
            lblWelcome_msg2.Visibility = Visibility.Visible;
            grdCustomerButtons.Visibility = Visibility.Visible;
        }
        public void loadCustomers()
        {
            Customer new_customer = new Customer ("Timothy de Jesus", "250 Brent Ln. Pensacola, Fl", 123456789);
            Bank.AddCustomer(new_customer);
            txtCustomer_Details.Text = new_customer.ToString();

            for (int x = 0; x <= Bank.customerList.Count -1; x++)
            {
                Button customer_button = new Button();
                customer_button.Content = $"{Bank.customerList[x].customer_name}";
                customer_button.Name = $"btnCustomerNew{x}";
                customer_button.Visibility = Visibility.Visible;
                customer_button.Click += new RoutedEventHandler(customer_button_Click);
                //(object s, RoutedEventArgs e) => { txtCustomer_Details.Visibility = Visibility.Visible; };
                grdCustomerButtons.Children.Add(customer_button);
            }
        }

        protected void customer_button_Click(object sender, RoutedEventArgs e)
        {
            txtCustomer_Details.Visibility = Visibility.Visible;
        }

        public void loadBank()
        {
            var new_bank = new List<Bank>
            {
                new Bank("Bank of Ruptcy", "888 Bank Blvd. Pensacola, FL.", 0987654321)
            };
            txtBank_Name.Text = new_bank[0].ToString();
        }

        private void btnExit_Bank_Click(object sender, RoutedEventArgs e)
        {
            txtCustomer_Details.Visibility = Visibility.Hidden;
            btnExit_Bank.Visibility = Visibility.Hidden;
            txtBank_Name.Visibility = Visibility.Hidden;
            btnEnterBank.Visibility = Visibility.Visible;
            lblWelcome_msg1.Visibility = Visibility.Hidden;
            lblWelcome_msg2.Visibility = Visibility.Hidden;
            grdCustomerButtons.Visibility = Visibility.Hidden;
        }
        public void loadCustomerButtons()
        {
            txtCustomer_Details.Visibility = Visibility.Hidden;
            txtBank_Name.Visibility = Visibility.Hidden;
            btnExit_Bank.Visibility = Visibility.Hidden;
            btnEnterBank.Visibility = Visibility.Visible;            
            lblWelcome_msg1.Visibility = Visibility.Hidden;
            lblWelcome_msg2.Visibility = Visibility.Hidden;
        }
    }
}
