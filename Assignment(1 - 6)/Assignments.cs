namespace Banking_System.Assignment_1___6_
{
    internal class Assignments
    {
        public void assignment1()
        { 
            ////: In a bank, you have been given the task is to create a program that checks if a customer is 
            //eligible for a loan based on their credit score and income. The eligibility criteria are as follows:
            //• Credit Score must be above 700.
            //• Annual Income must be at least $50,000.

            //Tasks:
            //1.Write a program that takes the customer's credit score and annual income as input.
            //2. Use conditional statements (if-else) to determine if the customer is eligible for a loan.
            //3. Display an appropriate message based on eligibility.

            Console.WriteLine("Welcome to .NET Bank");
            Console.WriteLine("Check whether your are eligible for loan\n");
            Console.WriteLine("1. Enter your Credit Score");
            int creditScore = int.Parse(Console.ReadLine());
            Console.WriteLine("");
            Console.WriteLine("2. Enter your Annual Income");
            int annualIncome = int.Parse(Console.ReadLine());
            Console.WriteLine("");

            if (creditScore > 700 && annualIncome > 50000)
            {
                Console.WriteLine("Congratulations!, You are eligible for the Loan");
            }
            else
            {
                Console.WriteLine("We regret to inform you that you are not eligible for the Loan");
            }
        }

        public void assignment2()
        {
            //Create a program that simulates an ATM transaction. Display options such as "Check 
            //Balance," "Withdraw," "Deposit,". Ask the user to enter their current balance and the amount they want 
            //to withdraw or deposit. Implement checks to ensure that the withdrawal amount is not greater than the 
            //available balance and that the withdrawal amount is in multiples of 100 or 500. Display appropriate 
            //messages for success or failure.

            Console.WriteLine("Welcome to .NET ATM");
            int userPin = 1131;
            Console.WriteLine("\nPlease Enter your Pin Number");
            int userEnteredPin = int.Parse(Console.ReadLine());
            if (userEnteredPin == userPin)
            {
                Console.WriteLine("\nPlease Enter your Balance");
                int userBalance = int.Parse(Console.ReadLine());
                string choice = @"Please Choose From Below:
            Press 1 for Check Balance
            Press 2 for Withdraw
            Press 3 for Deposit";
                Console.WriteLine($"\n{choice}");
                int userChoice = int.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine($"\nYour Balance Amount is Rs {userBalance}");
                        break;
                    case 2:
                        Console.WriteLine($"\nPlease enter your Withdrawal Amount");
                        int withdrawalAmount = int.Parse(Console.ReadLine());
                        if ((withdrawalAmount % 500 == 0) || (withdrawalAmount % 100 == 0))
                        {
                            if (withdrawalAmount < userBalance)
                            {
                                userBalance = userBalance - withdrawalAmount;
                                Console.WriteLine($"\nAn amount of Rs {withdrawalAmount} is withdrawn from your Account\nAvailable Balance is Rs {userBalance}");
                            }
                            else
                            {
                                Console.WriteLine($"\nYour Withdrawal Amount Exceeds the Balance of your Account");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"\nPlease enter your Withdrawal Amount in multiples of 500 or 100");
                        }
                        break;
                    case 3:
                        Console.WriteLine($"\nPlease enter the your Deposit Amount");
                        int depositAmount = int.Parse(Console.ReadLine());
                        userBalance = userBalance + depositAmount;
                        Console.WriteLine($"\nAn amount of Rs {depositAmount} is deposited to your Account\nAvailable Balance is Rs {userBalance}");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nInvalid Pin Number");
            }
        }

        public void assignment3()
        {
            //You are responsible for calculating compound interest on savings accounts for bank 
            //customers. You need to calculate the future balance for each customer's savings account after a certain 
            //number of years.

            //Tasks:
            //1. Create a program that calculates the future balance of a savings account.
            //2. Use a loop structure (e.g., for loop) to calculate the balance for multiple customers.
            //3. Prompt the user to enter the initial balance, annual interest rate, and the number of years.
            //4. Calculate the future balance using the formula: future_balance = initial_balance * (1 + annual_interest_rate / 100) ^ years.
            //5. Display the future balance for each customer.

            Console.WriteLine("Welcome to .NET Bank");
            Console.WriteLine("Know your Future Balance in three Steps");
            for (int i = 1; i < 3; i++)
            {
                Console.WriteLine($"\nCustomer No: {i}");
                Console.WriteLine("Please Enter your Initial Balance");
                double initialBalance = double.Parse(Console.ReadLine());
                Console.WriteLine("Please Enter your Annual Interest Rate");
                double annualInterestRate = double.Parse(Console.ReadLine());
                Console.WriteLine("Please Enter (No of years from today) to calculate your Future Savings");
                double noOfYears = int.Parse(Console.ReadLine());
                double calculatedBalance = (1 + (annualInterestRate / 100));
                double futureBalance = Math.Pow(calculatedBalance, noOfYears);
                futureBalance = futureBalance * initialBalance;
                Console.WriteLine($"Your Future Balance from {noOfYears} years is {futureBalance}");
            }
        }

        public void assignment4()
        {
            //Scenario: You are tasked with creating a program that allows bank customers to check their account 
            //balances. The program should handle multiple customer accounts, and the customer should be able to 
            //enter their account number, balance to check the balance.
            //Tasks:
            //1.Create a Python program that simulates a bank with multiple customer accounts.
            //2. Use a loop (e.g., while loop) to repeatedly ask the user for their account number and 
            //balance until they enter a valid account number.
            //3. Validate the account number entered by the user.
            //4. If the account number is valid, display the account balance. If not, ask the user to try again

            Console.WriteLine("Welcome to .NET Bank");
            Console.WriteLine("Check your Account Balance with 1 step\n");
            int[] accountNumber = { 123456, 654321 };
            for (int i = 0; i < accountNumber.Length; i++)
            {
                Console.WriteLine($"Customer Number {i + 1} :: Enter your Account Number");
                int accNo = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter your Bank Balance");
                int bankBalance = int.Parse(Console.ReadLine());
                while (accNo != accountNumber[i])
                {
                    Console.WriteLine("\nInvalid Account Number,Try Again\n");
                    Console.WriteLine($"Customer Number {i + 1} :: Enter your Account Number");
                    accNo = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter your Bank Balance");
                    bankBalance = int.Parse(Console.ReadLine());
                }
                Console.WriteLine($"\nWelcome! Account No: {accountNumber[i]}");
                Console.WriteLine($"Your available bank balance is {bankBalance}\n");
            }
        }

        public void assignment5()
        {
            //Write a program that prompts the user to create a password for their bank account. Implement if 
            //conditions to validate the password according to these rules:
            //• The password must be at least 8 characters long.
            //• It must contain at least one uppercase letter.
            //• It must contain at least one digit.
            //• Display appropriate messages to indicate whether their password is valid or not.

            

            Console.WriteLine("Welcome to .NET Bank");
            Console.WriteLine("Password Validation\n");
            restart:
            Console.WriteLine("Please Enter your Password");
            string password = Console.ReadLine();
            if (password.Length >= 8)
            {
                if (password.Any(char.IsUpper))
                {
                    if (password.Any(char.IsDigit))
                    {
                        Console.WriteLine("\nYour password was Successfully created!");
                    }
                    else
                    {
                        Console.WriteLine("It must contain at least one digit\n");
                        goto restart;
                    }
                }
                else
                {
                    Console.WriteLine("It must contain at least one uppercase letter.\n");
                    goto restart;
                }
            }
            else
            {
                Console.WriteLine("The password must be at least 8 characters long\n");
                goto restart;
            }
        }

        public void assignment6()
        {
            //Create a program that maintains a list of bank transactions (deposits and withdrawals) for a customer. 
            //Use a while loop to allow the user to keep adding transactions until they choose to exit. Display the 
            //transaction history upon exit using looping statements.

            Console.WriteLine("Welcome to .NET Bank");
            List<string> depositsAndWithdrawals = new List<string>();
            bool start = true;
            while (start)
            {
                Console.WriteLine("\nAdd Transactions");
                string transaction = Console.ReadLine();
                depositsAndWithdrawals.Add(transaction);
                Console.WriteLine("\nDo you wish to Continue\n 1.Yes 2.No");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 2)
                {
                    start = false;
                }
            }
            Console.WriteLine("\nTransactions History\n");
            int i = 1;
            foreach (string dw in depositsAndWithdrawals)
            {
                Console.WriteLine($"Transaction {i}");
                Console.WriteLine($"{dw}\n");
                i++;
            }
        }
    }
}






