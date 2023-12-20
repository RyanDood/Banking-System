using Banking_System_5.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Banking_System_5.dao
{
    internal interface IBankRepository
    {
        public bool createAccount(Customers customer, string accountType, float balance);
        public List<Accounts> listAccounts();
        public float calculateInterest(long accountNumber);
        public float getAccountBalance(long accountNumber);
        public float deposit(long accountNumber, float amount);
        public float withdraw(long accountNumber, float amount);
        public bool transfer(long fromAccountNumber, long toAccountNumber, float amount);
        public object getAccountDetails(long accountNumber);
        public List<Transactions> getTransactions(long accountNumber, string fromDate, string toDate);
        public List<Transactions> getAllTransactions();
        public List<Customers> getAllCustomers();
    }
}
