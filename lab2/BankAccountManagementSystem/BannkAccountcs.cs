using System;
using System.Collections.Generic;

enum AccountType
{
    Generic,
    Current,
    Saving,
    Business
}

class BankAccount
{
    public static string BankName { get; private set; }

    public string AccountName { get; set; }

    public long AccountNumber { get; }

    // Protected so child classes can access it
    protected decimal Balance { get; set; }

    public AccountType AccountType { get; set; } = AccountType.Generic;

    public bool IsActive { get; } = true;

    public List<string> TransactionHistory { get; } = new List<string>();

    // Static constructor
    static BankAccount()
    {
        BankName = "Global Trust Bank";
    }

    // Constructor
    public BankAccount(string accountName, long accountNumber)
    {
        AccountName = accountName;
        AccountNumber = accountNumber;
        Balance = 0.0m;

        TransactionHistory.Add(
            $"Account created for {AccountName}"
        );
    }

    // Deposit
    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Deposit amount must be positive.");
            return;
        }

        Balance += (decimal)amount;

        TransactionHistory.Add(
            $"Deposited: {amount} | Balance: {Balance}"
        );

        Console.WriteLine($"Deposited: {amount}");
    }

    // Withdrawal
    public void Withdrawal(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Withdrawal amount must be positive.");
            return;
        }

        if ((decimal)amount > Balance)
        {
            Console.WriteLine("Insufficient balance.");
            return;
        }

        Balance -= (decimal)amount;

        TransactionHistory.Add(
            $"Withdrawn: {amount} | Balance: {Balance}"
        );

        Console.WriteLine($"Withdrawn: {amount}");
    }

    // virtual allows child classes to override this method
    public virtual void DisplayAccountInfo()
    {
        Console.WriteLine("\n===== ACCOUNT INFORMATION =====");
        Console.WriteLine($"Bank Name      : {BankName}");
        Console.WriteLine($"Account Name   : {AccountName}");
        Console.WriteLine($"Account Number : {AccountNumber}");
        Console.WriteLine($"Account Type   : {AccountType}");
        Console.WriteLine($"Balance        : {Balance}");
        Console.WriteLine($"Active         : {IsActive}");

        Console.WriteLine("\nTransaction History:");

        foreach (string transaction in TransactionHistory)
        {
            Console.WriteLine(transaction);
        }
    }
}