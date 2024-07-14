using System;
using System.Collections.Generic;
using System.Security.Principal;

class Program
{
    private static List<Account> accounts = new List<Account>();

    public static List<Account> GetAccounts()
    {
        return accounts;
    }

    static void Main(string[] args)
    {
        accounts.Add(new Account("John Wick", "johnwick", 1000m, "Baba Yaga", 1));
        accounts.Add(new Account("Tony Stark", "tonystark", 500m, "Pepper Potts", 2));

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Online Banking!");
            Console.Write("Please enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Please enter your password: ");
            string password = Console.ReadLine();
            Account? currentAccount = Account.Login(username, password, GetAccounts());

            if (currentAccount != null)
            {
                Menu.DisplayAccountDetails(currentAccount);
                bool exit = false;

                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome, {currentAccount.Username}!");
                    Menu.DisplayMenu();

                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            Menu.Deposit(currentAccount);
                            break;
                        case 2:
                            Menu.Transfer(currentAccount);
                            break;
                        case 3:
                            Menu.LoadCash(currentAccount);
                            break;
                        case 4:
                            Menu.ShowTransactionHistory(currentAccount);
                            break;
                        case 5:
                            Menu.CheckBalance(currentAccount);
                            break;
                        case 6:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }

                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid credentials. Please try again.");
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}