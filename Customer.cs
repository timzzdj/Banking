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
        public string customer_name;
        public string customer_address;
        public int customer_phone_number;
        public static List<Account> accountList;
        // Constructors Default/Non-default
        public Customer() { }
        public Customer(string cus_name, string cus_addr, int cus_phone_num)
        {
            customer_name = cus_name;
            customer_address = cus_addr;
            customer_phone_number = cus_phone_num;
            accountList = new List<Account>();
        }
        // Methods
        public static void AddAccount(Account customerAccount)
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
