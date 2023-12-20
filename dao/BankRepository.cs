using Banking_System_5.entity;
using Banking_System_5.util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Banking_System_5.dao
{
    internal class BankRepository : IBankRepository
    {
        string connectionString = DBConnUtil.getConnectionString();
        public float calculateInterest(long accountNumber)
        {
            float accountBalance = -1;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "select balance from Accounts where account_id  = @accountID";
                    sqlCommand.Parameters.AddWithValue("@accountID", accountNumber);
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        decimal balance = (decimal)reader["balance"];
                        float convertedBalance = (float)(Decimal.ToDouble(balance));
                        accountBalance = convertedBalance * ( 4.5F/ 100);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write($"\n{e.Message}");
            }
            return accountBalance;
        }

        public bool createAccount(Customers customer, string accountType, float balance)
        {
            bool status = false;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "insert into Accounts values (@customerID,@accountType,@balance)";
                    sqlCommand.Parameters.AddWithValue("@customerID", customer.CustomerID);
                    sqlCommand.Parameters.AddWithValue("@accountType", accountType);
                    sqlCommand.Parameters.AddWithValue("@balance", balance);
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    int createProductStatus = sqlCommand.ExecuteNonQuery();
                    if (createProductStatus > 0)
                    {
                        status = true;
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                status = false;
            }
            return status;
        }

        public float deposit(long accountNumber, float amount)
        {
            float accountBalance = -1;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "update Accounts set balance = balance + @amount where account_id = @accountID";
                    sqlCommand.Parameters.AddWithValue("@accountID", accountNumber);
                    sqlCommand.Parameters.AddWithValue("@amount", amount);
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    int createOrderStatus = sqlCommand.ExecuteNonQuery();
                    if (createOrderStatus > 0)
                    {
                        accountBalance = getAccountBalance(accountNumber);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write($"\n{e.Message}");
            }
            return accountBalance;
        }

        public float getAccountBalance(long accountNumber)
        {
            float accountBalance = -1;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "select balance from Accounts where account_id  = @accountID";
                    sqlCommand.Parameters.AddWithValue("@accountID", accountNumber);
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        decimal balance = (decimal)reader["balance"];
                        float convertedBalance = (float)(Decimal.ToDouble(balance));
                        accountBalance = convertedBalance;
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write($"\n{e.Message}");
            }
            return accountBalance;
        }

        public object getAccountDetails(long accountNumber)
        {
            object accountDetails = new object();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "select account_id,account_type,balance,first_name,email,phone_number,address from Accounts inner join Customers on Accounts.customer_id = Customers.customer_id where account_id = @accountID";
                    sqlCommand.Parameters.AddWithValue("@accountID", accountNumber);
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        decimal balance = (decimal)reader["balance"];
                        float convertedBalance = (float)(Decimal.ToDouble(balance));
                        var getUserOrder = new { AccountID = (long)reader["account_id"], AccountType = (string)reader["account_type"], Balance = convertedBalance, FirstName = (string)reader["first_name"], Email = (string)reader["email"], PhoneNumber = (string)reader["phone_number"], Address = (string)reader["address"] };
                        accountDetails = getUserOrder;
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            return accountDetails;
        }

        public List<Customers> getAllCustomers()
        {
            List<Customers> getCustomers = new List<Customers>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "select * from Customers";
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime date = (DateTime)reader["DOB"];
                        string convertedDate = date.ToString("yyyy/MM/dd");
                        Customers customer = new Customers((int)reader["customer_id"], (string)reader["first_name"], (string)reader["last_name"], convertedDate, (string)reader["email"], (string)reader["phone_number"], (string)reader["address"]);
                        getCustomers.Add(customer);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write($"\n{e.Message}");
            }
            return getCustomers;
        }

        public List<Transactions> getAllTransactions()
        {
            List<Transactions> getTransactions = new List<Transactions>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "select * from Transactions";
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        decimal amount = (decimal)reader["amount"];
                        float convertedAmount = (float)(Decimal.ToDouble(amount));
                        DateTime date = (DateTime)reader["transaction_date"];
                        string convertedDate = date.ToString("yyyy/MM/dd");
                        Transactions transaction = new Transactions((int)reader["transaction_id"], (long)reader["account_id"], (string)reader["transaction_type"], convertedAmount, convertedDate);
                        getTransactions.Add(transaction);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write($"\n{e.Message}");
            }
            return getTransactions;
        }

        public List<Transactions> getTransactions(long accountNumber, string fromDate, string toDate)
        {
            List<Transactions> getTransactions = new List<Transactions>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "select * from Transactions where transaction_date between @fromDate and @toDate and account_id = @accountID";
                    sqlCommand.Parameters.AddWithValue("@accountID", accountNumber);
                    sqlCommand.Parameters.AddWithValue("@fromDate",fromDate);
                    sqlCommand.Parameters.AddWithValue("@toDate", toDate);
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        decimal amount = (decimal)reader["amount"];
                        float convertedAmount = (float)(Decimal.ToDouble(amount));
                        DateTime date = (DateTime)reader["transaction_date"];
                        string convertedDate = date.ToString("yyyy/MM/dd");
                        Transactions transaction = new Transactions((int)reader["transaction_id"], (long)reader["account_id"], (string)reader["transaction_type"], convertedAmount, convertedDate);
                        getTransactions.Add(transaction);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write($"\n{e.Message}\n");
            }
            return getTransactions;
        }

        public List<Accounts> listAccounts()
        {
            List<Accounts> getAccounts = new List<Accounts>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "select * from Accounts";
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        decimal balance = (decimal)reader["balance"];
                        float convertedBalance = (float)(Decimal.ToDouble(balance));
                        Accounts account = new Accounts((long)reader["account_id"], (int)reader["customer_id"], (string)reader["account_type"], convertedBalance);
                        getAccounts.Add(account);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write($"\n{e.Message}\n");
            }
            return getAccounts;
        }

        public bool transfer(long fromAccountNumber, long toAccountNumber, float amount)
        {
            bool status = false;
            try
            {
                float withdrawnBalance = withdraw(fromAccountNumber, amount);
                if (withdrawnBalance >= 0)
                {
                    float depositedBalance = deposit(toAccountNumber, amount);
                    if (depositedBalance >= 0)
                    {
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
            }
            catch (Exception e)
            {
                Console.Write($"\n{e.Message}");
            }
            return status;
        }

        public float withdraw(long accountNumber, float amount)
        {
            float accountBalance = -1;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = "update Accounts set balance = balance - @amount where account_id = @accountID";
                    sqlCommand.Parameters.AddWithValue("@accountID", accountNumber);
                    sqlCommand.Parameters.AddWithValue("@amount", amount);
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    int createOrderStatus = sqlCommand.ExecuteNonQuery();
                    if (createOrderStatus > 0)
                    {
                        accountBalance = getAccountBalance(accountNumber);
                    }
                }
            }
            catch (Exception e)
            {
                Console.Write($"\n{e.Message}");
            }
            return accountBalance;
        }
    }
}
