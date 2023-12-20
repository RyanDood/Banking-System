using Banking_System_4.Abstract;

namespace Banking_System_4.Entity
{
    internal class SavingsAccount : BankAccount
    {
        public float interestRate = 4.5F;

        public SavingsAccount(int accountNumber, string customerName, float balance) : base(accountNumber, customerName, balance)
        {
        }

        public override void deposit(float deposit)
        {
            balance = balance + deposit;
            Console.WriteLine($"\nAmount of {deposit} deposited successfully. Available Balance {balance}");
        }

        public override void withdraw(float withdraw)
        {
            if (balance < withdraw)
            {
                Console.WriteLine("\nInsufficient Fund");
            }
            else
            {
                balance = balance - withdraw;
                Console.WriteLine($"\nAmount of {withdraw} withdrawn successfully. Available Balance {balance}");
            }
        }

        public override void calculate_interest()
        {
            float interest = balance * (interestRate / 100);
            Console.WriteLine($"\nInterest of {interestRate}% for the available balance of {balance} is {interest}");
        }
    }
}
