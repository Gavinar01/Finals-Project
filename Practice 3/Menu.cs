using System;

public class Menu
{
    public static void DisplayMenu()
    {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Transfer");
        Console.WriteLine("3. Load cash to GCash or PayMaya");
        Console.WriteLine("4. Show transaction history");
        Console.WriteLine("5. Check balance");
        Console.WriteLine("6. Log out");
        Console.Write("Enter your choice: ");
    }

    public static void Deposit(Account account)
    {
        Console.Write("Enter the amount to deposit: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        account.Balance += amount;
        account.TransactionHistory.Add($"Deposit: {amount:C}");
    }

    public static void Transfer(Account account)
    {
        Console.Write("Enter the recipient's username: ");
        string recipientUsername = Console.ReadLine();
        Console.Write("Enter the amount to transfer: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        if (account.Balance >= amount)
        {
            account.Balance += amount;
            account.TransactionHistory.Add($"Transfer: {amount:C} to {recipientUsername}");


            Account recipientAccount = Program.GetAccounts().Find(a => String.Equals(a.Username, recipientUsername, StringComparison.OrdinalIgnoreCase));
            if (recipientAccount != null)
            {
                recipientAccount.Balance += amount;
                recipientAccount.TransactionHistory.Add($"Received transfer: {amount:C} from {account.Username}");
            }
            else
            {
                Console.WriteLine("Recipient account not found.");
            }
        }
        else
        {
            Console.WriteLine("Insufficient balance.");
        }
    }

    public static void LoadCash(Account account)
    {
        Console.WriteLine("Choose a payment method:");
        Console.WriteLine("1. GCash");
        Console.WriteLine("2. PayMaya");

        int choice = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the amount to load: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        if (amount > 0)
        {
            account.Balance -= amount;

            if (choice == 1)
            {
                account.TransactionHistory.Add($"Loaded {amount:C} to account {account.AccountNumber} via GCash.");
                Console.WriteLine($"Successfully loaded {amount:C} to account {account.AccountNumber} via GCash.");
            }
            else if (choice == 2)
            {
                account.TransactionHistory.Add($"Loaded {amount:C} to account {account.AccountNumber} via PayMaya.");
                Console.WriteLine($"Successfully loaded {amount:C} to account {account.AccountNumber} via PayMaya.");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }

    public static void ShowTransactionHistory(Account account)
    {
        foreach (string transaction in account.TransactionHistory)
        {
            Console.WriteLine(transaction);
        }
    }

    public static void CheckBalance(Account account)
    {
        Console.WriteLine($"Your current balance is: {account.Balance:C}");
    }

    public static void DisplayAccountDetails(Account? account)
    {
        if (account != null)
        {
            Console.WriteLine($"Name: {account.Name}");
            Console.WriteLine($"Username: {account.Username}");
            Console.WriteLine($"Password: {account.Password}");
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Balance: {account.Balance}");
        }
        else
        {
            Console.WriteLine("No account found.");
        }
    }
}