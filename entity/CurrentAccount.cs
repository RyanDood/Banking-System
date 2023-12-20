using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System_5.entity
{
    internal class CurrentAccount : Accounts
    {
        float overDraftLimit;
        public string branchName = null;
        
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
