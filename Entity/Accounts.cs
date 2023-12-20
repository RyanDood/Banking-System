namespace Banking_System_6.entity
{
    internal class Accounts
    {
        long account_id;
        int customer_id;
        string account_type;
        float balance;

        public Accounts(long accountID,int customerID,string accountType,float accbalance)
        {
            account_id = accountID;
            customer_id = customerID;
            account_type = accountType;
            balance = accbalance;
        }

        public long AccountID
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

        public override string ToString()
        {
            return $"\nAccount ID::{AccountID}\t Customer ID::{CustomerID}\t Account Type::{AccountType}\t Balance::{Balance}";
        }
    }
}
