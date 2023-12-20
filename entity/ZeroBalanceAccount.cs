using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System_5.entity
{
    internal class ZeroBalanceAccount : Accounts
    {
        public ZeroBalanceAccount(int accountID, int customerID, string accountType, float accbalance) : base(accountID, customerID, accountType, accbalance)
        {
        }
    }
}
