using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a BankAccount object
        BankAccount account = new BankAccount(
            "Sugam Kumar",
            1234567890
        );

        // Set account type
        account.AccountType = AccountType.Saving;

        // Deposit money
        account.Deposit(10000);

        // Withdraw money
        account.Withdrawal(2500);

        // Display account information
        account.DisplayAccountInfo();

        Console.ReadLine();
    }
}