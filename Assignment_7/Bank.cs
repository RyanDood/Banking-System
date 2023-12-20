namespace Banking_System_2.Assignment_7
{
    internal class Bank
    {
        public void banking()
        {
            Console.WriteLine($"Enter your Bank Balance");
            float userBalance = float.Parse(Console.ReadLine());

            Accounts accounts = new Accounts(1, 1, "Savings", userBalance);

            Console.WriteLine($"Your Current Balance::{accounts.Balance}");

        restart:
            Console.WriteLine("\nEnter your choice\n\n1. Deposit\n2. Withdrawal\n3. Calculate Interest\n");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine($"\nEnter the amount you want to deposit");
                    float userDeposit = float.Parse(Console.ReadLine());
                    accounts.deposit(userDeposit);
                    break;
                case 2:
                    Console.WriteLine($"\nEnter the amount you want to withdraw");
                    float userWithdrawal = float.Parse(Console.ReadLine());
                    accounts.withdraw(userWithdrawal);
                    break;
                case 3:
                    Console.WriteLine($"\nCalculate the interest of your account Balance");
                    accounts.calculate_interest();
                    break;
                default:
                    Console.WriteLine("Invalid Value");
                    break;
            }
            goto restart;

        }
    }
}
