using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1. Action<List<string>>
        // Prints each element of the list on a new line
        Action<List<string>> printList = (items) =>
        {
            foreach (string item in items)
            {
                Console.WriteLine(item);
            }
        };

        // Create a list
        List<string> names = new List<string>
        {
            "Sugam",
            "Sthapana",
            "Ram",
            "Shyam"
        };

        Console.WriteLine("List Elements:");
        printList(names);


        // 2. Func<int, bool>
        // Checks whether a number is even
        Func<int, bool> isEven = (number) =>
        {
            return number % 2 == 0;
        };

        int num1 = 10;

        Console.WriteLine("\nEven Number Check:");
        Console.WriteLine($"{num1} is even: {isEven(num1)}");


        // 3. Predicate<int>
        // Checks whether a number is a multiple of 5
        Predicate<int> isMultipleOf5 = (number) =>
        {
            return number % 5 == 0;
        };

        int num2 = 25;

        Console.WriteLine("\nMultiple of 5 Check:");
        Console.WriteLine($"{num2} is a multiple of 5: {isMultipleOf5(num2)}");

        Console.ReadLine();
    }
}