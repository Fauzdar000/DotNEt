using System;

class CheckingAccount : BankAccount
{
    // Constructor
    public CheckingAccount(string accountName, long accountNumber)
        : base(accountName, accountNumber)
    {
        AccountType = AccountType.Current;
    }

    // Override DisplayAccountInfo
    public override void DisplayAccountInfo()
    {
        base.DisplayAccountInfo();

        Console.WriteLine("Account Category: Checking Account");
    }
}