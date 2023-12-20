using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System_5.entity
{
    internal class SavingsAccount : Accounts
    {
        float interestRate = 4.5F;
        float minimumBalance = 1000;
        public SavingsAccount(int accountID, int customerID, string accountType, float accbalance) : base(accountID, customerID, accountType, accbalance)
        {

        }

        public float InterestRate
        {
            get
            {
                return interestRate;
            }
            set
            {
                interestRate = value; 
            }
        }

        public float MinimumBalance
        {
            get
            {
                return minimumBalance;
            }
            set
            {
                minimumBalance = value;
            }
        }
    }
}
