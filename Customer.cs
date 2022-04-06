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
        private string customer_name;
        private string customer_address;
        private string customer_phone_number;
        private List<Account> accountList;
        // Constructors Default/Non-default
        public Customer() { }
        public Customer(string cus_name, string cus_addr, string cus_phone_num)
        {
            customer_name = cus_name;
            customer_address = cus_addr;
            customer_phone_number = cus_phone_num;
            accountList = new List<Account>();
        }
        public string CustomerName { get => customer_name; }
        public string CustomerAddress { get => customer_address; }
        public string CustomerPhone { get => customer_phone_number; }
        public List<Account> AccountsLists
        {
            get => accountList;
        }
        // Methods
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
