using Banking_System_8.Dao;

namespace Banking_System_8.Main
{
    internal class BankApp
    {
        public void banking()
        {
            
            HMBank hmBank = new HMBank();

            Console.WriteLine("----------------------Welcome to HBank--------------------\n");
            restart:
            try
            {
                Console.WriteLine("\nPlease Select from below\n");
                Console.WriteLine("1. Create Account\n2. Get All Accounts\n3. Get Account Balance\n4. Deposit\n5. Withdraw\n6. Transfer Amount\n7. Get Account and Customer Details\n8. Get All Customers\n9. Calculate Interest\n10. Exit\n");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        hmBank.createAccount();
                        break;
                    case 2:
                        hmBank.listAccounts();
                        break;
                    case 3:
                        hmBank.getAccountBalance();
                        break;
                    case 4:
                        hmBank.deposit();
                        break;
                    case 5:
                        hmBank.withdraw();
                        break;
                    case 6:
                        hmBank.transfer();
                        break;
                    case 7:
                        hmBank.getAccountDetails();
                        break;
                    case 8:
                        hmBank.listCustomers();
                        break;
                    case 9:
                       hmBank.calculateInterest();
                        break;
                    case 10:
                        throw new Exception("Exited Successfully");
                    default:
                        Console.WriteLine("\nTry Again\n");
                        break;
                }
                goto restart;
            }
            catch (Exception e)
            {
                Console.Write($"\n{e.Message}\n");
            }
        }
    }
}
