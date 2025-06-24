namespace Bank;

public class Account
{
    // To check the random account number is unique
    private static HashSet<int> usedAccountNumbers = new HashSet<int>();
    private static Random random = new Random();

    // General properties
    public int AccountNumber { get; private set; }
    public string OwnerName { get; private set; }
    public double Balance { get; private set; }
    
    public const double MinimumInitialBalance = 100;
    
    // Method create account
    public Account(string ownerName, double initialBalance)
    {
        if (initialBalance < MinimumInitialBalance)
        {
            throw new ArgumentException($"Initial balance must be greater than {MinimumInitialBalance}");
        }
        
        this.AccountNumber = GenerateUniqueAccount();
        this.OwnerName = ownerName;
        this.Balance = initialBalance;
    }

    // Method to create unique account number
    private int GenerateUniqueAccount()
    {
        int number;
        do
        {
            number = random.Next(10000, 99999);
        } while (usedAccountNumbers.Contains(number));
        
        usedAccountNumbers.Add(number);
        return number;
    }

    // Method for update balance with deposit amount
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    // Method for update balance with withdraw amount
    public void Withdraw(double amount)
    {
        if (amount > 0 && amount <= Balance)
        {
            Balance -= amount;
        }
    }
}