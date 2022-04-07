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
        private string bank_name;            // The Bank's Name
        private string bank_address;         // The Bank's Address
        private int bank_phone_number;       // The Bank's Phone Number
        private List<Customer> customerList; // The bank's Lists of Customers

        // Constructors Default/Non-default
        public Bank() { }
        public Bank(string bankName, string bankAddress, int bankPhoneNumber)
        {
            bank_name = bankName;
            bank_address = bankAddress;
            bank_phone_number = bankPhoneNumber;
            customerList = new List<Customer>();
        }
        // Properties
        public List<Customer> CustomerLists
        {
            get => customerList;
        }
        // Methods
        // Add a new customer to the Bank
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
