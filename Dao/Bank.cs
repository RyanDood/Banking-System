using Banking_System_6.entity;

namespace Banking_System_6.Dao
{
    internal class Bank
    {
        public List<Customers> customers = new List<Customers>();
        public List<Accounts> accounts = new List<Accounts>(); 
        public Bank()
        {
            customers = new List<Customers>
            {
                new Customers(1,"Ryan","Paul","2002-03-13","ryan@email.com","9876543210","Trichy,TamilNadu"),
                new Customers(2,"Arun","Vijay","1992-07-15","arun@email.com","9638527410","Chennai,TamilNadu"),
                new Customers(3,"Jabez","John","2001-02-02","jabez@email.com","8695742310","Bangalore,Karnataka")
            };

            accounts = new List<Accounts>
            {
                new Accounts(1001,1,"Savings",25000),
                new Accounts(1002,2,"Current",75000),
                new Accounts(1003,3,"Zero-Balance",125000),
            };
        }


        public bool createAccount(Customers customer, string accountType, float balance)
        {
            Accounts account = accounts[accounts.Count-1];
            long newAccountNumber = account.AccountID + 1;
            accounts.Add(new Accounts(newAccountNumber,customer.CustomerID,accountType,balance));
            return true;
        }

        public List<Accounts> getAllAccounts()
        {
            return accounts;
        }

        public float getAccountBalance(long accountNumber)
        {
            Accounts searchedAccount = accounts.Find(x => x.AccountID== accountNumber);
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

        public float deposit(long accountNumber,float amount)
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

        public float withdraw(long accountNumber, float amount)
        {
            Accounts searchedAccount = accounts.Find(x => x.AccountID == accountNumber);
            if (searchedAccount == null)
            {
                Console.WriteLine($"\nAccount ID {accountNumber} does not exist");
                return -1;
            }
            else
            {
                if (amount > searchedAccount.Balance)
                {
                    Console.WriteLine($"\nWithdrawal limit exceeded");
                    return -1;
                }
                else
                {
                    Console.WriteLine($"\nOld Balance for Account Number {accountNumber} is Rs.{searchedAccount.Balance}");
                    searchedAccount.Balance = searchedAccount.Balance - amount;
                    return searchedAccount.Balance;
                }
            }
        }

        public bool transfer(long fromAccountNumber,long toAccountNumber,float amount)
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

        public object getAccountDetails(long accountNumber)
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

        public List<Customers> getAllCustomers()
        {
            return customers;
        }
    }
}
