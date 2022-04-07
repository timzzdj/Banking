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
        private string bank_name;
        private string bank_address;
        private int bank_phone_number;
        private List<Customer> customerList;

        // Constructors Default/Non-default
        public Bank() { }
        public Bank(string bankName, string bankAddress, int bankPhoneNumber)
        {
            bank_name = bankName;
            bank_address = bankAddress;
            bank_phone_number = bankPhoneNumber;
            customerList = new List<Customer>();
        }
        public List<Customer> CustomerLists
        {
            get => customerList;
        }
        // Methods
        public void AddCustomer(Customer bankCustomer)
        {
            customerList.Add(bankCustomer);
            return;
        }
        public override string ToString()
        {
            return $"\tWelcome to the Bank of {bank_name}\nWe are located in {bank_address}\nCall us at: {bank_phone_number}";
        }
    }
}
