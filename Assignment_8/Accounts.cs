namespace Banking_System_3.Assignment_8
{
    internal class Accounts
    {
        protected int account_id;
        protected int customer_id;
        protected string account_type;
        protected float balance;

        public Accounts(int accountID,int customerID,string accountType,float accBalance)
        {
            account_id = accountID;
            customer_id = customerID;
            account_type = accountType;
            balance = accBalance;
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

        public void deposit(int deposit)
        {
            balance = balance + deposit;
            Console.WriteLine($"\nAmount of {deposit} deposited successfully. Available Balance {balance}");
        }

        public void deposit(double deposit)
        {
            balance = (float)(balance + deposit);
            Console.WriteLine($"\nAmount of {deposit} deposited successfully. Available Balance {balance}");
        }

        public virtual void withdraw(float withdraw)
        {
            if(balance < withdraw)
            {
                Console.WriteLine("\nInsufficient Fund");
            }
            else
            {
                balance = balance - withdraw;
                Console.WriteLine($"\nAmount of {withdraw} withdrawn successfully. Available Balance {balance}");
            }
        }

        public virtual void withdraw(int withdraw)
        {
            if (balance < withdraw)
            {
                Console.WriteLine("\nInsufficient Fund");
            }
            else
            {
                balance = balance - withdraw;
                Console.WriteLine($"\nAmount of {withdraw} withdrawn successfully. Available Balance {balance}");
            }
        }

        public virtual void withdraw(double withdraw)
        {
            if (balance < withdraw)
            {
                Console.WriteLine("\nInsufficient Fund");
            }
            else
            {
                balance = (float)(balance - withdraw);
                Console.WriteLine($"\nAmount of {withdraw} withdrawn successfully. Available Balance {balance}");
            }
        }


        public virtual void calculate_interest()
        {
            float interest = balance * (4.5f / 100);
            Console.WriteLine($"\nInterest of 4.5% for the available balance of {balance} is {interest}");
        }
    }
}
