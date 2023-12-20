namespace Banking_System_5.entity
{
    internal class Transactions
    {
        int transaction_id;
        long account_id;
        string transaction_type;
        float amount;
        string transaction_date;

        public Transactions(int transactionID, long accountID, string transactionType, float totalAmount, string transactionDate)
        {
            transaction_id = transactionID;
            account_id = accountID;
            transaction_type = transactionType;
            amount = totalAmount;
            transaction_date = transactionDate;
        }

        public int TransactionID
        {
            get
            {
                return transaction_id;
            }
            set
            {
                transaction_id = value;
            }
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

        public string TransactionType
        {
            get
            {
                return transaction_type;
            }
            set
            {
                transaction_type = value;
            }
        }

        public float Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }

        public string TransactionDate
        {
            get
            {
                return transaction_date;
            }
            set
            {
                transaction_date = value;
            }
        }

        public override string ToString()
        {
            return $"\nTransaction ID::{TransactionID}\t Account ID::{account_id}\t Transaction Type::{TransactionType}\t Amount::{Amount}\t Transaction Date::{TransactionDate}";
        }
    }
}
