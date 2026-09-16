using System;

class Program
{
    // 1. Define a delegate
    public delegate void MessageHandler();

    // 2. Method to display welcome message
    static void ShowWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Method to display goodbye message
    static void ShowGoodbye()
    {
        Console.WriteLine("Goodbye! Have a nice day!");
    }

    static void Main(string[] args)
    {
        // 3. Single-cast delegate
        // Delegate points only to ShowWelcome()
        MessageHandler message = ShowWelcome;

        Console.WriteLine("Single-cast Delegate:");
        message();

        // 4. Multi-cast delegate
        // Add ShowGoodbye() to the delegate
        message += ShowGoodbye;

        Console.WriteLine("\nMulti-cast Delegate:");
        message();

        // 5. Remove ShowWelcome()
        message -= ShowWelcome;

        Console.WriteLine("\nAfter removing ShowWelcome():");
        message();

        Console.ReadLine();
    }
}