using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project05
{
    internal class Customer
    {
        public string customer_name;
        public string customer_address;
        public int customer_phone_number;
        private List<Account> accountList;
       // private static void ListAccounts() { var accounts = new List<Account>(); }
        public Customer() { }
        public Customer(string cus_name, string cus_addr, int cus_phone_num)
        {
            customer_name = cus_name;
            customer_address = cus_addr;
            customer_phone_number = cus_phone_num;
            var accountList = new List<Account>();
        }
        public void addAccount(Account customerAccount)
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
