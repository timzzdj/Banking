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
        private static void ListCustomers() { var customers = new List<Customer>(); }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
