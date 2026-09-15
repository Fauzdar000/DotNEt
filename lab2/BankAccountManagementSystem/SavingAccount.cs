using System;

class SavingsAccount : BankAccount
{
    // Interest rate = 4%
    public const double InterestRate = 4.0;

    // Constructor
    public SavingsAccount(string accountName, long accountNumber)
        : base(accountName, accountNumber)
    {
        AccountType = AccountType.Saving;
    }

    // Apply interest
    public void ApplyInterest()
    {
        double interest = (double)Balance * InterestRate / 100;

        // Use base class Deposit method
        base.Deposit(interest);

        Console.WriteLine($"Interest Applied: {interest}");
    }

    // Override DisplayAccountInfo
    public override void DisplayAccountInfo()
    {
        base.DisplayAccountInfo();

        Console.WriteLine($"Interest Rate  : {InterestRate}%");
    }
}