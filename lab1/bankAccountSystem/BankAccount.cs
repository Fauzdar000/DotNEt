using System;
using System.Collections.Generic;

// Enum for account types
enum AccountType
{
    Generic,
    Current,
    Saving,
    Business
}

class BankAccount
{
    // Static property
    public static string BankName { get; private set; }

    // Instance properties
    public string AccountName { get; set; }

    public long AccountNumber { get; }

    // Protected property - can be accessed inside this class
    // and by derived classes
    protected decimal Balance { get; set; }

    public AccountType AccountType { get; set; } = AccountType.Generic;

    // Read-only outside the class
    public bool IsActive { get; } = true;

    // Transaction history
    public List<string> TransactionHistory { get; } = new List<string>();

    // Static constructor
    static BankAccount()
    {
        BankName = "Global Trust Bank";
    }

    // Normal constructor
    public BankAccount(string accountName, long accountNumber)
    {
        AccountName = accountName;
        AccountNumber = accountNumber;
        Balance = 0.0m;

        // Add account creation transaction
        TransactionHistory.Add(
            $"Account created for {AccountName}. Initial Balance: {Balance:C}"
        );
    }

    // Deposit method
    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be positive.");
            return;
        }

        Balance += (decimal)amount;

        TransactionHistory.Add(
            $"Deposited: {amount:C} | Balance: {Balance:C}"
        );

        Console.WriteLine($"Successfully deposited {amount:C}");
    }

    // Withdrawal method
    public void Withdrawal(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be positive.");
            return;
        }

        if ((decimal)amount > Balance)
        {
            Console.WriteLine("Insufficient funds.");
            return;
        }

        Balance -= (decimal)amount;

        TransactionHistory.Add(
            $"Withdrawn: {amount:C} | Balance: {Balance:C}"
        );

        Console.WriteLine($"Successfully withdrawn {amount:C}");
    }

    // Display account information
    public void DisplayAccountInfo()
    {
        Console.WriteLine("\n========== ACCOUNT INFORMATION ==========");
        Console.WriteLine($"Bank Name      : {BankName}");
        Console.WriteLine($"Account Name   : {AccountName}");
        Console.WriteLine($"Account Number : {AccountNumber}");
        Console.WriteLine($"Account Type   : {AccountType}");
        Console.WriteLine($"Balance        : {Balance:C}");
        Console.WriteLine($"Active Status  : {IsActive}");

        Console.WriteLine("\n------- Transaction History -------");

        foreach (string transaction in TransactionHistory)
        {
            Console.WriteLine(transaction);
        }

        Console.WriteLine("=========================================");
    }
}