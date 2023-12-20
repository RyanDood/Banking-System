using Banking_System_8.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System_8.Dao
{
    internal class CustomerServiceProvider : ICustomerServiceProvider
    {

        public virtual float deposit(long accountNumber, float amount)
        {
            throw new NotImplementedException();
        }

        public virtual float getAccountBalance(long accountNumber)
        {
            throw new NotImplementedException();
        }

        public virtual object getAccountDetails(long accountNumber)
        {
            throw new NotImplementedException();
        }

        public virtual bool transfer(long fromAccountNumber, long toAccountNumber, float amount)
        {
            throw new NotImplementedException();
        }

        public virtual float withdraw(long accountNumber, float amount)
        {
            throw new NotImplementedException();
        }
    }
}
