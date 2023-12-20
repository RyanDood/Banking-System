using Banking_System_5.entity;
using Banking_System_5.exception;

namespace Banking_System_5.dao
{
    internal class BankServiceProvider : CustomerServiceProvider,IBankServiceProvider
    {

        IBankRepository bankRepository = new BankRepository();
      
        string branchName = null;
        string branchAddress;

        public void calculateInterest()
        {
            try
            {
                Console.WriteLine("\nGet Interest of your Savings Account");
                Console.WriteLine("\nEnter Account ID:");
                long inputAccountID = long.Parse(Console.ReadLine());
                List<Accounts> getAllAccounts = bankRepository.listAccounts();
                AccountType accountType = AccountType.Savings;
                Accounts searchedAccount = getAllAccounts.Find(x => x.AccountID == inputAccountID && x.AccountType == accountType.ToString());
                if (searchedAccount == null)
                {
                    throw new InvalidAccountException($"Savings Account ID {inputAccountID} does not exist\n");
                }

                float accountInterest = bankRepository.calculateInterest(inputAccountID);
                if (accountInterest > 0)
                {
                    Console.WriteLine($"\n4.5% per year of Interest for the Savings Account Number:{inputAccountID} with a bank balance of {searchedAccount.Balance} is Rs.{accountInterest}");
                }
                else
                {
                    Console.WriteLine($"\nAccount Balance is not available");
                }
            }
            catch (Exception e)
            {
                Console.Write($"\n{e.Message}\n");
            }
        }

        public void createAccount()
        {
            try
            {
                Console.WriteLine("\nEnter Customer ID:");
                int inputCustomerID = int.Parse(Console.ReadLine());
                List<Customers> getAllCustomers = bankRepository.getAllCustomers();
                Customers searchedCustomer = getAllCustomers.Find(x => x.CustomerID == inputCustomerID);
                if (searchedCustomer == null)
                {
                    throw new InvalidCustomerException($"Customer ID {inputCustomerID} does not exist\n");
                }

                AccountType savings = AccountType.Savings;
                AccountType current = AccountType.Current;
                AccountType zeroBalance = AccountType.ZeroBalance;

                Console.WriteLine("\nEnter Account Type:");
                string inputAccountType = Console.ReadLine();
                List<Accounts> getAllAccounts = bankRepository.listAccounts();
                Accounts searchedAccount = getAllAccounts.Find(x => x.CustomerID == inputCustomerID && x.AccountType == inputAccountType);
                if (searchedAccount != null)
                {
                    throw new InvalidAccountException($"{inputAccountType} Account already exists for Customer ID {inputCustomerID}");
                }

                if (inputAccountType == savings.ToString())
                {
                    Console.WriteLine("\nEnter Account Balance (Should be greater than Rs.1000):");
                    float inputAccountBalance = float.Parse(Console.ReadLine());
                    if(inputAccountBalance > 1000)
                    {
                        if (bankRepository.createAccount(searchedCustomer,inputAccountType,inputAccountBalance))
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
                        throw new InsufficientFundException("Minimum Account Balance should be greater than Rs.1000");
                    }
                }
                else if (inputAccountType == current.ToString())
                {
                    Console.WriteLine("\nEnter Account Balance (OverDraft Amount of 25000 is awarded):");
                    float inputAccountBalance = float.Parse(Console.ReadLine());
                    if (inputAccountBalance >= 0)
                    {
                        float balanceWithOverDraft = inputAccountBalance + 25000;
                        if (bankRepository.createAccount(searchedCustomer, inputAccountType, balanceWithOverDraft))
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
                        throw new InsufficientFundException("Invalid Fund Value Entered");
                    }
                }
                else if (inputAccountType == zeroBalance.ToString())
                {
                    Console.WriteLine("\nEnter Account Balance (Minimum balance can be Rs.0):");
                    float inputAccountBalance = float.Parse(Console.ReadLine());
                    if (inputAccountBalance >= 0)
                    {
                        if (bankRepository.createAccount(searchedCustomer, inputAccountType, inputAccountBalance))
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
                        throw new InsufficientFundException("Invalid Fund Value Entered");
                    }
                }
                else
                {
                    throw new InvalidAccountException("\nInvalid Account Type: Accounts can only exist as 1.Savings,2.Current,3.ZeroBalance");
                }  
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"\n{e.Message}\n");
            }
        }

        public override void getAccountDetails()
        {
            
        }

        public void getAllCustomers()
        {
            Console.WriteLine("\nAll Customer Details");
            List<Customers> allCustomers = bankRepository.getAllCustomers();
            foreach (var customer in allCustomers)
            {
                Console.WriteLine(customer);
            }
            Console.WriteLine("");
        }

        public void listAccounts()
        {
            Console.WriteLine("\nAll Account Details");
            List<Accounts> allAccounts = bankRepository.listAccounts();
            foreach (var account in allAccounts)
            {
                Console.WriteLine(account);
            }
            Console.WriteLine("");
        }

        public void executeException()
        {
            if (branchName == null)
            {
                throw new NullPointerException("Value is null, can't perform methods");
            }
            else
            {
                Console.WriteLine($"\n{branchName.ToUpper()}");
            }
        }
    }
}
