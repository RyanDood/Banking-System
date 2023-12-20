using Banking_System_6.entity;

namespace Banking_System_6.Dao
{
    internal class BankService
    {
        Bank bank = new Bank();
        public void createAccount()
        {
            Console.WriteLine("\nEnter Customer ID:");
            int inputCustomerID = int.Parse(Console.ReadLine());
            List<Customers> getAllCustomers = bank.customers;
            Customers searchedCustomer = getAllCustomers.Find(x => x.CustomerID == inputCustomerID);
            if (searchedCustomer == null)
            {
                Console.WriteLine($"Customer ID {inputCustomerID} does not exist\n");
            }
            else
            {
                Console.WriteLine("\nEnter Account Type:");
                string inputAccountType = Console.ReadLine();
                List<Accounts> getAllAccounts = bank.accounts;
                Accounts searchedAccount = getAllAccounts.Find(x => x.CustomerID == inputCustomerID && x.AccountType == inputAccountType);
                if (searchedAccount != null)
                {
                    Console.WriteLine($"{inputAccountType} Account already exists for Customer ID {inputCustomerID}");
                }
                else
                {
                    AccountType savings = AccountType.Savings;
                    AccountType current = AccountType.Current;
                    AccountType zeroBalance = AccountType.ZeroBalance;

                    if (inputAccountType == savings.ToString())
                    {
                        Console.WriteLine("\nEnter Account Balance (Should be greater than Rs.1000):");
                        float inputAccountBalance = float.Parse(Console.ReadLine());
                        if (inputAccountBalance > 1000)
                        {
                            if (bank.createAccount(searchedCustomer, inputAccountType, inputAccountBalance))
                            {
                                Console.WriteLine($"\nAccount was created successfully\n");
                            }
                            else
                            {
                                Console.WriteLine($"Unable to Create Account\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Minimum Account Balance should be greater than Rs.1000");
                        }
                    }
                    else if (inputAccountType == current.ToString())
                    {
                        Console.WriteLine("\nEnter Account Balance (OverDraft Amount of 25000 is awarded):");
                        float inputAccountBalance = float.Parse(Console.ReadLine());
                        if (inputAccountBalance >= 0)
                        {
                            float balanceWithOverDraft = inputAccountBalance + 25000;
                            if (bank.createAccount(searchedCustomer, inputAccountType, balanceWithOverDraft))
                            {
                                Console.WriteLine($"\nAccount was created successfully\n");
                            }
                            else
                            {
                                Console.WriteLine($"Unable to Create Account\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Fund Value Entered");
                        }
                    }
                    else if (inputAccountType == zeroBalance.ToString())
                    {
                        Console.WriteLine("\nEnter Account Balance (Minimum balance can be Rs.0):");
                        float inputAccountBalance = float.Parse(Console.ReadLine());
                        if (inputAccountBalance >= 0)
                        {
                            if (bank.createAccount(searchedCustomer, inputAccountType, inputAccountBalance))
                            {
                                Console.WriteLine($"\nAccount was created successfully\n");
                            }
                            else
                            {
                                Console.WriteLine($"Unable to Create Account\n");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Fund Value Entered");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid Account Type: Accounts can only exist as 1.Savings,2.Current,3.ZeroBalance");
                    }
                }
            }
        }

        public void getAllAccounts()
        {
            List<Accounts> allAccounts = bank.getAllAccounts();
            foreach (var account in allAccounts)
            {
                Console.WriteLine(account);
            }
            Console.WriteLine("");
        }

        public void getAccountBalance()
        {
            Console.WriteLine("\nGet Account Balance:");
            Console.WriteLine("\nEnter Account Number:");
            long inputAccountID = long.Parse(Console.ReadLine());
            if (bank.getAccountBalance(inputAccountID) >= 0)
            {
                Console.WriteLine($"\nAccount Balance for {inputAccountID} is Rs.{bank.getAccountBalance(inputAccountID)}");
            }
            else
            {
                Console.WriteLine($"Account Balance not fetched");
            }
        }

        public void deposit()
        {
            Console.WriteLine("\nDeposit to your Account");
            Console.WriteLine("\nEnter Account ID:");
            long inputAccountID = long.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Amount");
            float inputAccountBalance = float.Parse(Console.ReadLine());

            if (inputAccountBalance > 0)
            {
                if (bank.deposit(inputAccountID, inputAccountBalance) >= 0)
                {
                    Console.WriteLine($"\nUpdated Account Balance for {inputAccountID} is Rs.{bank.getAccountBalance(inputAccountID)}");
                }
                else
                {
                    Console.WriteLine($"\nAccount Balance not fetched");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid Fund Value");
            }
        }

        public void withdraw()
        {
            Console.WriteLine("\nWithdraw from your Account");
            Console.WriteLine("\nEnter Account ID:");
            long inputAccountID = long.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Amount");
            float inputAccountBalance = float.Parse(Console.ReadLine());

            if (inputAccountBalance > 0)
            {
                if (bank.withdraw(inputAccountID, inputAccountBalance) >= 0)
                {
                    Console.WriteLine($"\nUpdated Account Balance for {inputAccountID} is Rs.{bank.getAccountBalance(inputAccountID)}");
                }
                else
                {
                    Console.WriteLine($"\nAccount Balance not fetched");
                }
            }
            else
            {
                Console.WriteLine("\nInvalid Fund Value");
            }
        }

        public void transfer()
        {
            Console.WriteLine("\nTransfer money to another Account");
            Console.WriteLine("\nFrom Account Number:");
            long inputFromAccountID = long.Parse(Console.ReadLine());
            
            Console.WriteLine("\nTo Account Number:");
            long inputToAccountID = long.Parse(Console.ReadLine());
            
            Console.WriteLine("\nEnter Amount");
            float inputAmount = float.Parse(Console.ReadLine());
            if (inputAmount > 0)
            {
                if (bank.transfer(inputFromAccountID, inputToAccountID, inputAmount))
                {
                    Console.WriteLine($"\nAn amount of {inputAmount} is transferred from {inputFromAccountID} to {inputToAccountID}");
                }
                else
                {
                    Console.WriteLine("Unable to Transfer Money\n");
                }
            }
            else
            {
                Console.WriteLine($"\nInvalid Fund Value\n");
            }
        }

        public void getAccountDetails()
        {
            Console.WriteLine("\nTransfer money to another Account");
            Console.WriteLine("\nFrom Account Number:");
            long inputFromAccountID = long.Parse(Console.ReadLine());
            Console.WriteLine(bank.getAccountDetails(inputFromAccountID));
        }

        public void getAllCustomers()
        {
            List<Customers> allCustomers = bank.getAllCustomers();
            foreach (var customer in allCustomers)
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine("");
        }
    }
}
