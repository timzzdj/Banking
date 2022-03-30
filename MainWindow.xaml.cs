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
        }

        private void btnEnterBank_Click(object sender, RoutedEventArgs e)
        {
            loadCustomerAccounts();
        }
        public void loadCustomerAccounts()
        {
            var new_account = new List<Customer>()
            {
                new Customer(){ customer_name = "Timothy de Jesus", customer_address = "250 Brent Ln. Pensacola, Fl", customer_phone_number = 123456789 }
            };
        }
    }
}
