namespace Banking_System_3.Assignment_8
{
    internal class CurrentAccount : Accounts
    {
        const int overdraftLimit = 50000;
        
        public CurrentAccount(int accountID, int customerID, string accountType, float accBalance) : base(accountID, customerID, accountType, accBalance)
        {
            
        }

        public override void withdraw(float withdraw)
        {
            float calculatedBalance = balance + overdraftLimit;
            if(withdraw > calculatedBalance)
            {
                Console.WriteLine("\nInsufficient Fund, you have exceeded the OverDraft Limit");
            }
            else
            {
                balance = balance - withdraw;
                if (balance < 0)
                {
                    Console.WriteLine($"\nAmount of {withdraw} withdrawn successfully. Available OverdraftBalance {overdraftLimit + balance}");
                }
                else
                {
                    Console.WriteLine($"\nAmount of {withdraw} withdrawn successfully. Available Balance {balance}");
                }
            }
        }

        public override void withdraw(int withdraw)
        {
            float calculatedBalance = balance + overdraftLimit;
            if (withdraw > calculatedBalance)
            {
                Console.WriteLine("\nInsufficient Fund, you have exceeded the OverDraft Limit");
            }
            else
            {
                balance = balance - withdraw;
                if(balance < 0)
                {
                    Console.WriteLine($"\nAmount of {withdraw} withdrawn successfully. Available OverdraftBalance {overdraftLimit + balance}");
                }
                else
                {
                    Console.WriteLine($"\nAmount of {withdraw} withdrawn successfully. Available Balance {balance}");
                }
            }
        }

        public override void withdraw(double withdraw)
        {
            float calculatedBalance = balance + overdraftLimit;
            if (withdraw > calculatedBalance)
            {
                Console.WriteLine("\nInsufficient Fund, you have exceeded the OverDraft Limit");
            }
            else
            {
                balance = (float)(balance - withdraw);
                if (balance < 0)
                {
                    Console.WriteLine($"\nAmount of {withdraw} withdrawn successfully. Available OverdraftBalance {overdraftLimit + balance}");
                }
                else
                {
                    Console.WriteLine($"\nAmount of {withdraw} withdrawn successfully. Available Balance {balance}");
                }
            }
        }
    }
}
