using Banking_System_8.entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System_8.Dao
{
    internal class BankServiceProvider : CustomerServiceProvider,IBankServiceProvider
    {
        public List<Customers> customers = new List<Customers>
        {
                new Customers(1,"Ryan","Paul","2002-03-13","ryan@email.com","9876543210","Trichy,TamilNadu"),
                new Customers(2,"Arun","Vijay","1992-07-15","arun@email.com","9638527410","Chennai,TamilNadu"),
                new Customers(3,"Jabez","John","2001-02-02","jabez@email.com","8695742310","Bangalore,Karnataka")
        };
        public List<Accounts> accounts = new List<Accounts>
        { 
                new Accounts(1001,1,"Savings",25000),
                new Accounts(1002,2,"Current",75000),
                new Accounts(1003,3,"ZeroBalance",125000),
        };

        public float calculateInterest(long accountNumber)
        {
            AccountType savings = AccountType.Savings;

            Accounts searchedAccount = accounts.Find(x => x.AccountID == accountNumber && x.AccountType == savings.ToString());
            if (searchedAccount == null)
            {
                Console.WriteLine($"\nSavings Account ID {accountNumber} does not exist");
                return -1;
            }
            else
            {
                SavingsAccount savingsAccount = new SavingsAccount(1, 1, "1", 1);
                float interestRate = savingsAccount.InterestRate;

                float interest = searchedAccount.Balance * (interestRate / 100);

                return interest;
            }
        }

        public bool createAccount(Customers customer, string accountType, float balance)
        {
            Accounts account = accounts[accounts.Count - 1];
            long newAccountNumber = account.AccountID + 1;
            accounts.Add(new Accounts(newAccountNumber, customer.CustomerID, accountType, balance));
            return true;
        }

        public List<Accounts> listAccounts()
        {
            return accounts;
        }

        public List<Customers> listCustomers()
        {
            return customers;
        }

        public override float getAccountBalance(long accountNumber)
        {
            Accounts searchedAccount = accounts.Find(x => x.AccountID == accountNumber);
            if (searchedAccount == null)
            {
                Console.WriteLine($"\nAccount ID {accountNumber} does not exist");
                return -1;
            }
            else
            {
                return searchedAccount.Balance;
            }
        }

        public override float deposit(long accountNumber, float amount)
        {
            Accounts searchedAccount = accounts.Find(x => x.AccountID == accountNumber);
            if (searchedAccount == null)
            {
                Console.WriteLine($"\nAccount ID {accountNumber} does not exist");
                return -1;
            }
            else
            {
                Console.WriteLine($"\nOld Balance for Account Number {accountNumber} is Rs.{searchedAccount.Balance}");
                searchedAccount.Balance = searchedAccount.Balance + amount;
                return searchedAccount.Balance;
            }
        }

        public override object getAccountDetails(long accountNumber)
        {
            object accountDetails = new object();
            Accounts searchedAccount = accounts.Find(x => x.AccountID == accountNumber);
            if (searchedAccount == null)
            {
                Console.WriteLine($"\nAccount ID {accountNumber} does not exist");
                return null;
            }
            else
            {
                Customers searchedCustomer = customers.Find(x => x.CustomerID == searchedAccount.CustomerID);
                if (searchedCustomer == null)
                {
                    Console.WriteLine($"\nCustomer ID {searchedCustomer.CustomerID} does not exist");
                    return null;
                }
                else
                {
                    var getDetails = new { AccountID = searchedAccount.AccountID, AccountType = searchedAccount.AccountType, Balance = searchedAccount.Balance, FirstName = searchedCustomer.FirstName, Email = searchedCustomer.Email, PhoneNumber = searchedCustomer.PhoneNumber, Address = searchedCustomer.Address };
                    accountDetails = getDetails;
                    return accountDetails;
                }
            }
        }

        public override bool transfer(long fromAccountNumber, long toAccountNumber, float amount)
        {
            bool status = false;
            Accounts searchedFromAccount = accounts.Find(x => x.AccountID == fromAccountNumber);
            if (searchedFromAccount == null)
            {
                Console.WriteLine($"\nAccount ID {fromAccountNumber} does not exist");
                return false;
            }
            else
            {
                Accounts searchedToAccount = accounts.Find(x => x.AccountID == toAccountNumber);
                if (searchedToAccount == null)
                {
                    Console.WriteLine($"\nAccount ID {toAccountNumber} does not exist");
                    return false;
                }
                else
                {
                    float withdrawnBalance = withdraw(fromAccountNumber, amount);
                    if (withdrawnBalance >= 0)
                    {
                        Console.WriteLine($"Updated Account Balance for Account Number {fromAccountNumber} is Rs.{withdrawnBalance}");
                        float depositedBalance = deposit(toAccountNumber, amount);
                        if (depositedBalance >= 0)
                        {
                            Console.WriteLine($"Updated Account Balance for Account Number {toAccountNumber} is Rs.{depositedBalance}");
                            status = true;
                        }
                        else
                        {
                            status = false;
                        }
                    }
                    else
                    {
                        status = false;
                    }
                    return status;
                }
            }
        }

        public override float withdraw(long accountNumber, float amount)
        {
            Accounts searchedAccount = accounts.Find(x => x.AccountID == accountNumber);
            if (searchedAccount == null)
            {
                Console.WriteLine($"\nAccount ID {accountNumber} does not exist");
                return -1;
            }
            else
            {
                if(amount > searchedAccount.Balance)
                {
                    Console.WriteLine($"\nWithdrawal limit exceeded");
                    return -1;
                }
                else
                {
                    AccountType savings = AccountType.Savings;
                    AccountType current = AccountType.Current;
                    AccountType zeroBalance = AccountType.ZeroBalance;

                    if (searchedAccount.AccountType == savings.ToString())
                    {
                        SavingsAccount savingsAccount = new SavingsAccount(1,1,"1",1);

                        float mininumBalance =  savingsAccount.MinimumBalance;
                        float withdrawnResult = searchedAccount.Balance - amount;

                        if(withdrawnResult >= mininumBalance)
                        {
                            Console.WriteLine($"\nOld Balance for Account Number {accountNumber} is Rs.{searchedAccount.Balance}");
                            searchedAccount.Balance = searchedAccount.Balance - amount;
                            return searchedAccount.Balance;
                        }
                        else
                        {
                            Console.WriteLine("\nWithdrawal amount exceeds the Minimum Account Balance Value of 500");
                            return -1;
                        }
                    }

                    else if(searchedAccount.AccountType == current.ToString())
                    {
                        CurrentAccount currentAccount = new CurrentAccount(1,1,"1",1);

                        float withdrawnResult = searchedAccount.Balance - amount;
                        float overDraftValue = currentAccount.OverDraftLimit;

                        if (withdrawnResult >= 0 && withdrawnResult <= overDraftValue)
                        {
                            searchedAccount.Balance = withdrawnResult;
                            Console.WriteLine($"\nAccount Balance for Current Account Number:{accountNumber} is Rs.{0} with OverDraft Limit of Rs.{searchedAccount.Balance}");
                            return searchedAccount.Balance;
                        }
                        else if(withdrawnResult >= 0)
                        {
                            searchedAccount.Balance = withdrawnResult;
                            Console.WriteLine($"\nAccount Balance for Current Account Number:{accountNumber} is Rs.{searchedAccount.Balance - overDraftValue} with OverDraft Limit of Rs.{overDraftValue}");
                            return searchedAccount.Balance;
                        }
                        else
                        {
                            Console.WriteLine("\nWithdrawal amount exceeds the Minimum Account Balance Value of 0");
                            return -1;
                        }
                    }
                    else if(searchedAccount.AccountType == zeroBalance.ToString())
                    {
                        float withdrawnResult = searchedAccount.Balance - amount;

                        if (withdrawnResult >= 0)
                        {
                            Console.WriteLine($"\nOld Balance for Account Number {accountNumber} is Rs.{searchedAccount.Balance}");
                            searchedAccount.Balance = searchedAccount.Balance - amount;
                            return searchedAccount.Balance;
                        }
                        else
                        {
                            Console.WriteLine("\nWithdrawal amount exceeds the Minimum Account Balance Value of 0");
                            return -1;
                        }
                    }
                    return -1;
                }
            }
        }
    }
}
