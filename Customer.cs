using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project05
{
    internal class Customer
    {
        // Fields
        private string customer_name;         // The customer's name
        private string customer_address;      // The customer's address
        private string customer_phone_number; // The customer's phone number
        private List<Account> accountList;    // The customer's lists of accounts

        // Constructors Default/Non-default
        public Customer() { }
        public Customer(string cus_name, string cus_addr, string cus_phone_num)
        {
            customer_name = cus_name;
            customer_address = cus_addr;
            customer_phone_number = cus_phone_num;
            accountList = new List<Account>();
        }
        // Properties
        public string CustomerName { get => customer_name; }
        public string CustomerAddress { get => customer_address; }
        public string CustomerPhone { get => customer_phone_number; }
        public List<Account> AccountsLists
        {
            get => accountList;
        }
        // Methods
        /* Add a newly created account to the Customer*/
        public void AddAccount(Account customerAccount)
        {
            accountList.Add(customerAccount);
            return;
        }
        public override string ToString()
        {
            return $"\t--Customer information--\n\tCustomer Name:{customer_name}\n\tCustomer Address:{customer_address}\n\tCustomer Phone Number:{customer_phone_number}\n";
        }
    }
}
