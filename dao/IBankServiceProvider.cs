using Banking_System_5.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System_5.dao
{
    internal interface IBankServiceProvider
    {
        public void createAccount();
        public void listAccounts();
        public void getAccountDetails();
        public void calculateInterest();
        public void getAllCustomers();
        public void executeException();
    }
}
