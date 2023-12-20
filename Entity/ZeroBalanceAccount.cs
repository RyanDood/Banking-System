namespace Banking_System_8.entity
{
    internal class ZeroBalanceAccount : Accounts
    {
        public ZeroBalanceAccount(int accountID, int customerID, string accountType, float accbalance) : base(accountID, customerID, accountType, accbalance)
        {
        }
    }
}
