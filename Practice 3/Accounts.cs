using System;
using System.Collections.Generic;

public class Account
{
    public string Username { get; set; }
    public string Password { get; set; }
    public decimal Balance { get; set; }
    public string Name { get; set; }
    public int AccountNumber { get; set; } 
    public List<string> TransactionHistory { get; set; }

    public Account(string username, string password, decimal balance, string name, int accountNumber)
    {
        Username = username;
        Password = password;
        Balance = balance;
        Name = name;
        AccountNumber = accountNumber; 
        TransactionHistory = new List<string>();
    }

    public static Account? Login(string username, string password, List<Account> accounts)
    {
        foreach (Account account in accounts)
        {
            if (account.Username == username && account.Password == password)
            {
                return account;
            }
        }
        return null;
    }
}