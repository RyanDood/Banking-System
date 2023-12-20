using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Banking_System_5.dao
{
    internal interface ICustomerServiceProvider
    {
        public void getAccountBalance();
        public void deposit();
        public void withdraw();
        public void transfer();
        public void getAccountDetails();
        public void getTransactions();
        public void getAllTransactions();
    }
}
