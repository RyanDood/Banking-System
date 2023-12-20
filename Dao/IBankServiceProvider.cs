using Banking_System_8.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System_8.Dao
{
    internal interface IBankServiceProvider
    {
        public bool createAccount(Customers customer, string accountType, float balance);
        public List<Accounts> listAccounts();
        public float calculateInterest(long accountNumber);
        public List<Customers> listCustomers();
    }
}
