// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

string? input;
List<int> numbers;
do
{
    numbers = new List<int>();

    do
    {
        Console.Write("Enter an Integer: ");
        input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            int num;
            if (int.TryParse(input, out num))
            {
                numbers.Add(num);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    } while (!string.IsNullOrEmpty(input));

    if (numbers.Count == 0)
    {
        Console.WriteLine("You did not enter any integer.");
    }
    else
    {
        // Max and Min of integers
        var maxNumbers = numbers.Max();
        var minNumbers = numbers.Min();

        // Filter even/odd of intergers
        var oddNumbers = numbers.Where(n => n % 2 != 0).ToList();
        var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();

        // Count even/odd integers
        int oddCount = oddNumbers.Count;
        int evenCount = evenNumbers.Count;

        // Sum of even/odd integers
        int oddSum = oddNumbers.Sum();
        int evenSum = evenNumbers.Sum();

        // Average of even/odd integers
        double oddAvg = oddCount > 0 ? (double)oddSum / oddCount : 0;
        double evenAvg = evenCount > 0 ? (double)evenSum / evenCount : 0;

        Console.WriteLine($"The maximum integer you enter is: {maxNumbers}");
        Console.WriteLine($"The minimum integer you enter is: {minNumbers}");
        Console.WriteLine($"\nThe number of odd integer(s) you entered is: {oddCount}");
        Console.WriteLine($"The sum of all odd integer(s) you entered is: {oddSum}");
        Console.WriteLine($"The average of all odd integer(s) you entered is: {oddAvg:F2}");
        Console.WriteLine($"\nThe number of even integer(s) you entered is: {evenCount}");
        Console.WriteLine($"The sum of all even integer(s) you entered is: {evenSum}");
        Console.WriteLine($"The average of all even integer(s) you entered is: {evenAvg:F2}");
    }

    Console.Write("\nPlay again? (Y/y) ");
    string play = Console.ReadLine();
    if (play != "Y")
        break;
} while (true);
