// See https://aka.ms/new-console-template for more information

namespace Bank;

public class Program
{
    // List of Accounts
    static List<Account> accounts = new List<Account>();
    public static void Main(string[] args)
    {
        bool isDone = false;
        
        Console.WriteLine("Welcome to the bank!");
        
        // Main menu
        do
        {
            Console.WriteLine("\nPlease choose an option:");
            Console.WriteLine("1) View accounts");
            Console.WriteLine("2) Create an account");
            Console.WriteLine("3) Deposit");
            Console.WriteLine("4) Withdraw");
            Console.WriteLine("5) Exit");
            string input = Console.ReadLine();
            
            // Validate user input
            if (!int.TryParse(input, out int userInput))
            {
                Console.WriteLine("\nPlease enter a valid integer");
                continue;
            }

            if (userInput < 1 || userInput > 5)
            {
                Console.WriteLine("\nInvalid option selected.");
                continue;
            }
            
            // user option
            switch ((Option)userInput)
            {
                case Option.ViewAccounts:
                    viewAccounts();
                    break;
                case Option.CreateAccount:
                    CreateAccount();
                    break;
                case Option.Deposit:
                    Deposit();
                    break;
                case Option.Withdraw:
                    Withdraw();
                    break;
                case Option.Exit:
                    isDone = true;
                    Console.WriteLine("Goodbye!");
                    break;
            }
        } while (!isDone);

        // Method for view total account
        static void viewAccounts()
        {
            if (accounts.Count == 0)
            {
                Console.WriteLine("\nNo accounts found.");
                return;
            }

            Console.WriteLine($"\n{accounts.Count} accounts found.");
            foreach (var account in accounts)
            {
                Console.WriteLine($"{account.AccountNumber,-5}: {account.OwnerName,-18}{account.Balance:C2}");
            }
        }

        // Method create account
        static void CreateAccount()
        {
            string accountName;
            double newBalance;
            while (true)
            {
                Console.WriteLine("\nEnter the account owner's name");
                string ownerName = Console.ReadLine();
                
                // Check null or white space input
                if (string.IsNullOrWhiteSpace(ownerName))
                {
                    Console.WriteLine("\nInvalid account owner's name.");
                    continue;
                }
                if (int.TryParse(ownerName, out _))
                {
                    Console.WriteLine("\nAccount owner's must not contain an integer.");
                    continue;
                }
                accountName = ownerName;
                break;
            }

            while (true)
            {
                Console.WriteLine("\nEnter the initial balance");
                string userInitial = Console.ReadLine();
                if (double.TryParse(userInitial, out newBalance))
                {
                    if (newBalance < Account.MinimumInitialBalance)
                    {
                        Console.WriteLine("\nInitial balance must be greater than $100.00");
                        continue;
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid input. Please try again.");
                }
            }
            Account newAccount = new Account(accountName, newBalance);
            accounts.Add(newAccount);
            Console.WriteLine("\nAccount created successfully.");
            Console.WriteLine($"{newAccount.AccountNumber,-5}: {newAccount.OwnerName,-18}\t{newAccount.Balance:C2}");
        }

        // Method for deposit
        static void Deposit()
        {
            Account foundAccount = null;
            while (true)
            {
                Console.WriteLine("\nEnter the account number: ");
                string userAccountNumber = Console.ReadLine();
                
                if (int.TryParse(userAccountNumber, out int userAccountNo))
                {
                    // Check if account found in the list
                    foreach (var acc in accounts)
                    {
                        if (acc.AccountNumber == userAccountNo)
                        {
                            foundAccount = acc;
                            break;
                        }
                    }
                    // Check account found
                    if (foundAccount != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nAccount not found. Please try again.");
                    }
                }
            }

            while (true)
            {
                Console.WriteLine("\nEnter the amount to deposit: ");
                string userAmount = Console.ReadLine();

                if (double.TryParse(userAmount, out double userDepositAmount))
                {
                    if (userDepositAmount >= 0)
                    {
                        foundAccount.Deposit(userDepositAmount);
                        Console.WriteLine("\nDeposit successful.");
                        Console.WriteLine($"{foundAccount.AccountNumber,-5}: {foundAccount.OwnerName,-18}{foundAccount.Balance:C2}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid deposit amount. Please try again.");
                    }
                }
            }
        }

        // Method for withdraw
        static void Withdraw()
        {
            Account accountWithdraw = null;
            
            while (true)
            {
                Console.WriteLine("\nEnter the account number: ");
                string userAccountNumber = Console.ReadLine();
                
                if (int.TryParse(userAccountNumber, out int userAccountNo))
                {
                    // Check if account found in the list
                    foreach (var acc in accounts)
                    {
                        if (acc.AccountNumber == userAccountNo)
                        {
                            accountWithdraw = acc;
                            break;
                        }
                    }
                    // Check account found
                    if (accountWithdraw != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nAccount not found. Please try again.");
                    }
                }
            }
            while (true)
            {
                Console.WriteLine("\nEnter the withdraw amount: ");
                string userWithdrawAmount = Console.ReadLine();
                
                // Validate withdraw amount
                if (double.TryParse(userWithdrawAmount, out double withdrawAmount))
                {
                    if (withdrawAmount >= 0)
                    {
                        accountWithdraw.Withdraw(withdrawAmount);
                        Console.WriteLine("\nWithdraw successful.");
                        Console.WriteLine($"{accountWithdraw.AccountNumber,-5}: {accountWithdraw.OwnerName,-18}{accountWithdraw.Balance:C2}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid withdraw amount. Please try again.");
                    }
                }
            }
        }
        
    }
    enum Option
    {
        ViewAccounts = 1,
        CreateAccount,
        Deposit,
        Withdraw,
        Exit
    };
}

