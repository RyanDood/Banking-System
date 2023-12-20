namespace Banking_System_3.Assignment_8
{
    internal class Bank
    {
        public void banking()
        {
            Console.WriteLine($"Enter your Bank Balance For Savings Account");
            float userSavingsBalance = float.Parse(Console.ReadLine());
            SavingsAccount savingsAccount = new SavingsAccount(1, 1, "Savings", userSavingsBalance);

            Console.WriteLine($"\nEnter your Bank Balance For Current Account");
            float userCurrentBalance = float.Parse(Console.ReadLine());
            CurrentAccount currentAccount = new CurrentAccount(1, 1, "Current", userCurrentBalance);

        restart:
            Console.WriteLine("\nChoose your Account\n\n1. Savings Account\n2. Current Account\n");
            int accountChoice = int.Parse(Console.ReadLine());

            switch (accountChoice)
            {
                case 1:
                    Console.WriteLine($"Your Current Balance::{savingsAccount.Balance}");
                    Console.WriteLine("\nEnter your choice\n\n1. Deposit\n2. Withdrawal\n3. Calculate Interest\n");
                    int savingsChoice = int.Parse(Console.ReadLine());
                    switch (savingsChoice)
                    {
                        case 1:
                            Console.WriteLine($"\nEnter the amount you want to deposit");
                            float userDeposit = float.Parse(Console.ReadLine());
                            savingsAccount.deposit(userDeposit);
                            break;
                        case 2:
                            Console.WriteLine($"\nEnter the amount you want to withdraw");
                            float userWithdrawal = float.Parse(Console.ReadLine());
                            savingsAccount.withdraw(userWithdrawal);
                            break;
                        case 3:
                            Console.WriteLine($"\nCalculate the interest of your account Balance");
                            Console.WriteLine("\nEnter your interest rate");
                            float inputInterest = float.Parse(Console.ReadLine());
                            savingsAccount.InterestRate = inputInterest;
                            savingsAccount.calculate_interest();
                            break;
                        default:
                            Console.WriteLine("Invalid Value");
                            break;
                    }
                    break;
                case 2:
                    Console.WriteLine($"Your Current Balance::{currentAccount.Balance}");
                    Console.WriteLine("\nEnter your choice\n\n1. Deposit\n2. Withdrawal\n\n");
                    int currentChoice = int.Parse(Console.ReadLine());
                    switch (currentChoice)
                    {
                        case 1:
                            Console.WriteLine($"\nEnter the amount you want to deposit");
                            float userDeposit = float.Parse(Console.ReadLine());
                            currentAccount.deposit(userDeposit);
                            break;
                        case 2:
                            Console.WriteLine($"\nEnter the amount you want to withdraw");
                            float userWithdrawal = float.Parse(Console.ReadLine());
                            currentAccount.withdraw(userWithdrawal);
                            break;
                        default:
                            Console.WriteLine("Invalid Value");
                            break;
                    }
                    break;
            }
            goto restart;
        }
    }
}
