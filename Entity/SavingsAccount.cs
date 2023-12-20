

namespace Banking_System_8.entity
{
    internal class SavingsAccount : Accounts
    {
        float interestRate = 4.5F;
        float minimumBalance = 500;
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
