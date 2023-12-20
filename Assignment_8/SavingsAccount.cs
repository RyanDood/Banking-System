namespace Banking_System_3.Assignment_8
{
    internal class SavingsAccount : Accounts
    {
        public float InterestRate { get; set; }
        
        public SavingsAccount(int accountID, int customerID, string accountType, float accBalance) : base(accountID, customerID, accountType, accBalance)
        {
            
        }

        public override void calculate_interest()
        {
            float interest = balance * (InterestRate / 100);
            Console.WriteLine($"\nInterest of {InterestRate}% for the available balance of {balance} is {interest}");
        }
    }
}
