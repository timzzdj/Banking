using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project05
{
    internal class Bank
    {
        // Fields
        public string bank_name;
        public string bank_address;
        public int bank_phone_number;
        private List<Customer> customerList;
        public Bank(string bankName, string bankAddress, int bankPhoneNumber)
        {
            bank_name = bankName;
            var customerList = new List<Customer>();
        }
      //  private static void ListCustomers() { var customers = new List<Customer>(); }
        public void addCustomer(Customer bankCustomer)
        {
            customerList.Add(bankCustomer);
            return;
        }
        public override string ToString()
        {
            return $"{bank_name}, {bank_address}, {bank_phone_number}, {customerList}";
        }
    }
}
