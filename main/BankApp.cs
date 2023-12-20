using Banking_System_5.dao;
using Banking_System_5.entity;
using Banking_System_5.exception;

namespace Banking_System_5.main
{
    internal class BankApp
    {
        public void banking()
        {
            IBankServiceProvider bankServiceProvider = new BankServiceProvider();
            ICustomerServiceProvider customerServiceProvider = new CustomerServiceProvider();

            Console.WriteLine("----------------------Welcome to HBank--------------------\n");
            restart:
            try
            {
                Console.WriteLine("\nPlease Select from below\n");
                Console.WriteLine("1. View All Accounts\n2. View All Transactions\n3. Get User Account Transactions Within a Particular Period\n4. Check Account Balance\n5. Check Interest for your Savings Account\n6. Deposit Amount\n7. Withdraw Amount\n8. Get Account and Customer Details\n9. Get All Customers\n10. Create Account for Existing Customer\n11. Transfer amount from Account to Account\n12. Execute Null Pointer Exception\n");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        bankServiceProvider.listAccounts();
                        break;
                    case 2:
                        customerServiceProvider.getAllTransactions();
                        break;
                    case 3:
                        customerServiceProvider.getTransactions();
                        break;
                    case 4:
                        customerServiceProvider.getAccountBalance();
                        break;
                    case 5:
                        bankServiceProvider.calculateInterest();
                        break;
                    case 6:
                        customerServiceProvider.deposit();
                        break;
                    case 7:
                        customerServiceProvider.withdraw();
                        break;
                    case 8:
                        customerServiceProvider.getAccountDetails();
                        break;
                    case 9:
                        bankServiceProvider.getAllCustomers();
                        break;
                    case 10:
                        bankServiceProvider.createAccount();
                        break;
                    case 11:
                        customerServiceProvider.transfer();
                        break;
                    case 12:
                        bankServiceProvider.executeException();
                        break;
                    default:
                        Console.WriteLine("\nTry Again\n");
                        break;
                }
                goto restart;
            }
            catch(Exception e)
            {
                Console.Write($"\n{e.Message}\n");
            }
        }
    }
}
