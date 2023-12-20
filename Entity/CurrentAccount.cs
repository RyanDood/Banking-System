using Banking_System_4.Abstract;

namespace Banking_System_4.Entity
{
    internal class CurrentAccount : BankAccount
    {
        const int overdraftLimit = 50000;

        public CurrentAccount(int accountNumber, string customerName, float balance) : base(accountNumber, customerName, balance)
        {

        }

        public override void deposit(float deposit)
        {
            balance = balance + deposit;
            Console.WriteLine($"\nAmount of {deposit} deposited successfully. Available Balance {balance}");
        }

        public override void withdraw(float withdraw)
        {
            float calculatedBalance = balance + overdraftLimit;
            if (withdraw > calculatedBalance)
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

        public override void calculate_interest()
        {

        }

    }
}
