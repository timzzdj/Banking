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
        public static List<Customer> customerList;

        // Constructors Default/Non-default
        public Bank() { }
        public Bank(string bankName, string bankAddress, int bankPhoneNumber)
        {
            bank_name = bankName;
            bank_address = bankAddress;
            bank_phone_number = bankPhoneNumber;
            customerList = new List<Customer>();
        }

        // Methods
        public static void AddCustomer(Customer bankCustomer)
        {
            customerList.Add(bankCustomer);
            return;
        }
        public override string ToString()
        {
            return $"\t\tWelcome to {bank_name}\nWe are located in {bank_address}\nCall us at: {bank_phone_number}\nHere is a list of our customers:";
        }
    }
}
