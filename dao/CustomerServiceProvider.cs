using Banking_System_5.entity;
using Banking_System_5.exception;

namespace Banking_System_5.dao
{
    internal class CustomerServiceProvider : ICustomerServiceProvider
    {
        IBankRepository bankRepository = new BankRepository();

        public void deposit()
        {
            try
            {
                Console.WriteLine("\nDeposit to your Account");
                Console.WriteLine("\nEnter Account ID:");
                long inputAccountID = long.Parse(Console.ReadLine());
                List<Accounts> getAllAccounts = bankRepository.listAccounts();
                Accounts searchedAccount = getAllAccounts.Find(x => x.AccountID == inputAccountID);
                if (searchedAccount == null)
                {
                    throw new InvalidAccountException($"Account ID {inputAccountID} does not exist\n");
                }

                Console.WriteLine($"\nAvailable Balance:{searchedAccount.Balance}");
                Console.WriteLine("\nEnter Deposit Amount:");
                float inputDepositAmount = float.Parse(Console.ReadLine());
                if(inputDepositAmount > 0)
                {
                    float accountBalance = bankRepository.deposit(inputAccountID, inputDepositAmount);
                    if (accountBalance > 0)
                    {
                        Console.WriteLine($"\nAccount Balance for Account Number:{inputAccountID} is Rs.{accountBalance}");
                    }
                    else
                    {
                        Console.WriteLine($"\nAccount Balance is not available");
                    }
                }
                else
                {

                    Console.WriteLine($"\nInvalid Deposit Amount\n");
                }    
            }
            catch (Exception e)
            {
                Console.Write($"\n{e.Message}\n");
            }
        }

        public void getAccountBalance()
        {
            try
            {
                Console.WriteLine("\nGet Customer Balance");
                Console.WriteLine("\nEnter Account ID:");
                long inputAccountID = long.Parse(Console.ReadLine());
                List<Accounts> getAllAccounts = bankRepository.listAccounts();
                Accounts searchedAccount = getAllAccounts.Find(x => x.AccountID == inputAccountID);
                if (searchedAccount == null)
                {
                    throw new InvalidAccountException($"Account ID {inputAccountID} does not exist\n");
                }

                AccountType savings = AccountType.Savings;
                AccountType current = AccountType.Current;
                AccountType zeroBalance = AccountType.ZeroBalance;

                float accountBalance = bankRepository.getAccountBalance(inputAccountID);
                if (accountBalance >= 0)
                {
                    if (searchedAccount.AccountType == savings.ToString())
                    {
                        Console.WriteLine($"\nAccount Balance for Savings Account Number:{inputAccountID} is Rs.{accountBalance}");
                    }
                    else if(searchedAccount.AccountType == current.ToString())
                    {
                        Console.WriteLine($"\nAccount Balance for Current Account Number:{inputAccountID} is Rs.{accountBalance - 25000} with OverDraft Limit of Rs.25000");
                    }
                    else if(searchedAccount.AccountType == zeroBalance.ToString())
                    {
                        Console.WriteLine($"\nAccount Balance for Zero Balance Account Number:{inputAccountID} is Rs.{accountBalance}");
                    }
                    else
                    {
                        Console.WriteLine($"\nInvalid Account Type");
                    }
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

        public virtual void getAccountDetails()
        {
            try
            {
                Console.WriteLine("\nAccount and Customer Details");
                Console.WriteLine("\nEnter Account ID:");
                long inputAccountID = long.Parse(Console.ReadLine());
                 List<Accounts> getAllAccounts = bankRepository.listAccounts();
                Accounts searchedAccount = getAllAccounts.Find(x => x.AccountID == inputAccountID);
                if (searchedAccount == null)
                {
                    throw new InvalidAccountException($"Account ID {inputAccountID} does not exist\n");
                }

                object accountDetails = bankRepository.getAccountDetails(inputAccountID);
                Console.WriteLine($"\n{accountDetails}\n");
            }
            catch (Exception e)
            {
                Console.Write($"\n{e.Message}\n");
            }
        }

        public void getTransactions()
        {
            try
            {
                Console.WriteLine("\nTransaction Details within a particular Date");
                Console.WriteLine("\nEnter Account ID:");
                long inputAccountID = long.Parse(Console.ReadLine());
                List<Transactions> allTransactions = bankRepository.getAllTransactions();
                Transactions searchedAccount = allTransactions.Find(x => x.AccountID == inputAccountID);
                if (searchedAccount == null)
                {
                    throw new InvalidAccountException($"Account ID {inputAccountID} does not exist or does not have a Transaction History\n");
                }

                Console.WriteLine("\nEnter From Date:");
                string inputFromDate = Console.ReadLine();
                Console.WriteLine("\nEnter To Date:");
                string inputToDate = Console.ReadLine();

                List<Transactions> userTransactions = bankRepository.getTransactions(inputAccountID, inputFromDate, inputToDate);
                if(userTransactions.Count > 0)
                {
                    foreach (var transaction in userTransactions)
                    {
                        Console.WriteLine(transaction);
                    }
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine($"\nNo Transaction History is present for the Account {inputAccountID} within {inputFromDate} to {inputToDate}");
                }
                
            }
            catch (Exception e)
            {
                Console.Write($"\n{e.Message}\n");
            }
        }

        public void getAllTransactions()
        {
            Console.WriteLine("\nAll Transaction Details");
            List<Transactions> allTransactions = bankRepository.getAllTransactions();
            foreach (var transaction in allTransactions)
            {
                Console.WriteLine(transaction);
            }
            Console.WriteLine("");
        }

        public void transfer()
        {
            try
            {
                Console.WriteLine("\nTransfer money to another Account");
                Console.WriteLine("\nFrom Account Number:");
                long inputFromAccountID = long.Parse(Console.ReadLine());
                List<Accounts> getAllAccounts = bankRepository.listAccounts();
                Accounts searchedFromAccount = getAllAccounts.Find(x => x.AccountID == inputFromAccountID);
                if (searchedFromAccount == null)
                {
                    throw new InvalidAccountException($"Account ID {inputFromAccountID} does not exist\n");
                }

                Console.WriteLine("\nTo Account Number:");
                long inputToAccountID = long.Parse(Console.ReadLine());
                Accounts searchedToAccount = getAllAccounts.Find(x => x.AccountID == inputToAccountID);
                if (searchedToAccount == null)
                {
                    throw new InvalidAccountException($"Account ID {inputToAccountID} does not exist\n");
                }

                Console.WriteLine("\nEnter Amount");
                float inputAmount = float.Parse(Console.ReadLine());
                if (inputAmount > 0)
                {
                    if (bankRepository.transfer(inputFromAccountID, inputToAccountID, inputAmount))
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
                    throw new InsufficientFundException($"Invalid Fund Value\n");
                }
            }
            catch (Exception e)
            {
                Console.Write($"\n{e.Message}\n");
            }
        }

        public void withdraw()
        {
            try
            {
                Console.WriteLine("\nWithdraw from your Account");
                Console.WriteLine("\nEnter Account ID:");
                long inputAccountID = long.Parse(Console.ReadLine());
                List<Accounts> getAllAccounts = bankRepository.listAccounts();
                Accounts searchedAccount = getAllAccounts.Find(x => x.AccountID == inputAccountID);
                if (searchedAccount == null)
                {
                    throw new InvalidAccountException($"Account ID {inputAccountID} does not exist\n");
                }

                AccountType savings = AccountType.Savings;
                AccountType current = AccountType.Current;
                AccountType zeroBalance = AccountType.ZeroBalance;

                Console.WriteLine($"\nAvailable Balance:{searchedAccount.Balance}");
                Console.WriteLine("\nEnter Withdraw Amount:");
                float inputWithdrawAmount = float.Parse(Console.ReadLine());
                if (inputWithdrawAmount > 0 && searchedAccount.AccountType == savings.ToString())
                {
                    float withdrawnResult = searchedAccount.Balance - inputWithdrawAmount;
                    if(withdrawnResult >= 1000)
                    {
                        float accountBalance = bankRepository.withdraw(inputAccountID, inputWithdrawAmount);
                        if (accountBalance > 0)
                        {
                            Console.WriteLine($"\nAccount Balance for Savings Account Number:{inputAccountID} is Rs.{accountBalance}");
                        }
                        else
                        {
                            Console.WriteLine($"\nAccount Balance is not available");
                        }
                    }
                    else
                    {
                        throw new InsufficientFundException("Withdrawal amount exceeds the Minimum Account Balance Value of 1000");
                    }    
                }
                else if(inputWithdrawAmount > 0 && searchedAccount.AccountType == current.ToString())
                {
                    float withdrawnResult = searchedAccount.Balance - inputWithdrawAmount;
                    float overDraftValue = 25000;
                    if(withdrawnResult <= overDraftValue)
                    {
                        if(withdrawnResult >= 0)
                        {
                            float accountBalance = bankRepository.withdraw(inputAccountID, inputWithdrawAmount);
                            if (accountBalance >= 0)
                            {
                                Console.WriteLine($"\nAccount Balance for Current Account Number:{inputAccountID} is Rs.{0} with OverDraft Limit of Rs.{accountBalance}");
                            }
                            else
                            {
                                Console.WriteLine($"\nAccount Balance is not available");
                            }
                        }
                        else
                        {
                            throw new OverDraftLimitExcededException("Withdrawal amount exceeds the Available Overdraft Balance");
                        }
                    }
                    else
                    {
                        float accountBalance = bankRepository.withdraw(inputAccountID, inputWithdrawAmount);
                        if (accountBalance >= 0)
                        {
                            Console.WriteLine($"\nAccount Balance for Current Account Number:{inputAccountID} is Rs.{accountBalance - overDraftValue} with OverDraft Limit of Rs.{overDraftValue}");
                        }
                        else
                        {
                            Console.WriteLine($"\nAccount Balance is not available");
                        }
                    }
                }
                else if (inputWithdrawAmount > 0 && searchedAccount.AccountType == zeroBalance.ToString())
                {
                    float withdrawnResult = searchedAccount.Balance - inputWithdrawAmount;
                    if(withdrawnResult >= 0)
                    {
                        float accountBalance = bankRepository.withdraw(inputAccountID, inputWithdrawAmount);
                        if (accountBalance >= 0)
                        {
                            Console.WriteLine($"\nAccount Balance for ZeroBalance Account Number:{inputAccountID} is Rs.{accountBalance}");
                        }
                        else
                        {
                            Console.WriteLine($"\nAccount Balance is not available");
                        }
                    }
                    else
                    {
                        throw new InsufficientFundException("Withdrawal amount exceeds the Minimum Account Balance Value of 0");
                    }
                }
                else
                {
                    Console.WriteLine($"\nInvalid Withdraw Amount\n");
                }
            }
            catch (Exception e)
            {
                Console.Write($"\n{e.Message}\n");
            }
        }
    }
}
