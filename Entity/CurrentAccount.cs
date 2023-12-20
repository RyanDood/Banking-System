using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System_8.entity
{
    internal class CurrentAccount : Accounts
    {
        float overDraftLimit = 25000;
  
        public CurrentAccount(int accountID, int customerID, string accountType, float accbalance) : base(accountID, customerID, accountType, accbalance)
        {

        }

        public float OverDraftLimit
        {
            get 
            { 
                return overDraftLimit;
            }
            set
            {
                overDraftLimit = value;
            }
        }
    }
}
