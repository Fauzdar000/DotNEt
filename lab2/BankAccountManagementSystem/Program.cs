using System;

class Program
{
    static void Main(string[] args)
    {
        // Create Savings Account
        SavingsAccount savings = new SavingsAccount(
            "Sugam Kumar",
            1234567890
        );

        // Deposit
        savings.Deposit(10000);

        // Withdraw
        savings.Withdrawal(2000);

        // Apply 4% interest
        savings.ApplyInterest();

        // Display savings account
        savings.DisplayAccountInfo();


        // --------------------------------
        // POLYMORPHISM
        // --------------------------------

        Console.WriteLine("\n\n===== POLYMORPHISM =====");

        // Base class reference
        BankAccount account;

        // Pointing to SavingsAccount object
        account = new SavingsAccount(
            "Ram Sharma",
            9876543210
        );

        account.Deposit(5000);

        // Calls SavingsAccount's overridden method
        account.DisplayAccountInfo();


        // Pointing to CheckingAccount object
        account = new CheckingAccount(
            "Hari Thapa",
            5555555555
        );

        account.Deposit(8000);

        // Calls CheckingAccount's overridden method
        account.DisplayAccountInfo();

        Console.ReadLine();
    }
}