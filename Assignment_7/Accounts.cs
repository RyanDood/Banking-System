namespace Banking_System_2.Assignment_7
{
    internal class Accounts
    {
        int account_id;
        int customer_id;
        string account_type;
        float balance;

        public Accounts(int accountID,int customerID,string accountType,float accbalance)
        {
            account_id = accountID;
            customer_id = customerID;
            account_type = accountType;
            balance = accbalance;
        }

        public int AccountID
        {
            get
            {
                return account_id;
            }
            set
            {
                account_id = value;
            }
        }

        public int CustomerID
        {
            get
            {
                return customer_id;
            }
            set
            {
                customer_id = value;
            }
        }

        public string AccountType
        {
            get
            {
                return account_type;
            }
            set
            {
                account_type = value;
            }
        }

        public float Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }

        public void deposit(float deposit)
        {
            balance = balance + deposit;
            Console.WriteLine($"\nAmount of {deposit} deposited successfully. Available Balance {balance}");
        }

        public void withdraw(float withdraw)
        {
            if(balance < withdraw)
            {
                Console.WriteLine("Insufficient Fund");
            }
            else
            {
                balance = balance - withdraw;
                Console.WriteLine($"\nAmount of {withdraw} withdrawn successfully. Available Balance {balance}");
            }
        }


        public void calculate_interest()
        {
            float interest = balance * (4.5f / 100);
            Console.WriteLine($"\nInterest of 4.5% for the available balance of {balance} is {interest}");
        }

        public override string ToString()
        {
            return $"Account ID::{AccountID}\t Customer ID::{CustomerID}\t Account Type::{AccountType}\t Balance::{Balance}";
        }
    }
}
