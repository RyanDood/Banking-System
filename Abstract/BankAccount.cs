namespace Banking_System_4.Abstract
{
    internal abstract class BankAccount
    {
        protected int accountNumber;
        protected string customerName;
        protected float balance;

        public BankAccount(int accountNumber, string customerName, float balance)
        {
            this.accountNumber = accountNumber;
            this.customerName = customerName;
            this.balance = balance;
        }

        public int AccountNumber
        {
            get
            {
                return accountNumber;
            }
            set
            {
                accountNumber = value;
            }
        }

        public string CustomerName
        {
            get
            {
                return customerName;
            }
            set
            {
                customerName = value;
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


        public abstract void deposit(float deposit);

        public abstract void withdraw(float withdraw);

        public abstract void calculate_interest();

        public override string ToString()
        {
            return $"Account Number::{AccountNumber}\t Customer Name::{CustomerName}\t Balance::{Balance}";
        }

    }
}
