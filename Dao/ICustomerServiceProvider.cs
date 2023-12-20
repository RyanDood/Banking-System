using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System_8.Dao
{
    internal interface ICustomerServiceProvider
    {
        public float getAccountBalance(long accountNumber);
        public float deposit(long accountNumber, float amount);
        public float withdraw(long accountNumber, float amount);
        public bool transfer(long fromAccountNumber, long toAccountNumber, float amount);
        public object getAccountDetails(long accountNumber);
    }
}
