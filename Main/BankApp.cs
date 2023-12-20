using Banking_System_6.Dao;

namespace Banking_System_6.Main
{
    internal class BankApp
    {
        public void banking()
        {
            BankService bankService = new BankService();

            Console.WriteLine("----------------------Welcome to HBank--------------------\n");
            restart:
            try
            {
                Console.WriteLine("\nPlease Select from below\n");
                Console.WriteLine("1. Create Account\n2. Get All Accounts\n3. Get Account Balance\n4. Deposit\n5. Withdraw\n6. Transfer Amount\n7. Get Account and Customer Details\n8. Get All Customers\n9. Exit\n");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        bankService.createAccount();
                        break;
                    case 2:
                        bankService.getAllAccounts();
                        break;
                    case 3:
                        bankService.getAccountBalance();
                        break;
                    case 4:
                        bankService.deposit();
                        break;
                    case 5:
                        bankService.withdraw();
                        break; 
                    case 6:
                        bankService.transfer();
                        break;
                    case 7:
                        bankService.getAccountDetails();
                        break;
                    case 8:
                        bankService.getAllCustomers();
                        break;
                    case 9:
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
