using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

class Program
{
    static string historyFile = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), 
        "shared_calculation_history.json"
    );
    static List<string> LoadHistory()
    {
        if (File.Exists(historyFile))
        {
            string json = File.ReadAllText(historyFile);
            return JsonConvert.DeserializeObject<List<string>>(json);
        }
        return new List<string>();
    }

    static void SaveHistory(List<string> history)
    {
        string json = JsonConvert.SerializeObject(history, Formatting.Indented);
        File.WriteAllText(historyFile, json);
    }

    static double Add(double x, double y) => x + y;
    static double Subtract(double x, double y) => x - y;
    static double Multiply(double x, double y) => x * y;
    static string Divide(double x, double y) => y == 0 ? "Error! Division by zero." : (x / y).ToString();
    static string SquareRoot(double x) => x < 0 ? "Error! Cannot take the square root of a negative number." : Math.Sqrt(x).ToString();

    static double GetNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out double number))
                return number;
            Console.WriteLine("Invalid input! Please enter a valid number.");
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("\nCalculator Menu:");
        Console.WriteLine("1. Perform basic Calculation");
        Console.WriteLine("2. Calculate square root");
        Console.WriteLine("3. View History");
        Console.WriteLine("4. Exit");
    }

    static void PerformBasicCalculation(List<string> history)
    {
        Console.WriteLine("\nBasic Calculation Menu:");
        Console.WriteLine("a. Add");
        Console.WriteLine("b. Subtract");
        Console.WriteLine("c. Multiply");
        Console.WriteLine("d. Divide");
        Console.Write("Choose an operation: ");
        string basicChoice = Console.ReadLine();

        double x = GetNumber("Enter first number: ");
        double y = GetNumber("Enter second number: ");
        string result = Calculate(x, y, basicChoice);
        if (result != null)
        {
            Console.WriteLine($"Result: {result}");
            history.Add(result);
        }
    }

    static string Calculate(double x, double y, string operation)
    {
        return operation switch
        {
            "a" => $"Added {x} + {y} = {Add(x, y)}",
            "b" => $"Subtracted {x} - {y} = {Subtract(x, y)}",
            "c" => $"Multiplied {x} * {y} = {Multiply(x, y)}",
            "d" => $"Divided {x} / {y} = {Divide(x, y)}",
            
        };
    }

    static void HandleUserChoice(List<string> history)
    {
        while (true)
        {
            ShowMenu();
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PerformBasicCalculation(history);
                    break;
                case "2":
                    double x = GetNumber("Enter number to find the square root: ");
                    string result = SquareRoot(x);
                    Console.WriteLine($"Result: {result}");
                    history.Add($"Square root of {x} = {result}");
                    break;
                case "3":
                    foreach (string entry in history)
                        Console.WriteLine(entry);
                    break;
                case "4":
                    SaveHistory(history);
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice! Please try again.");
                    break;
            }
        }
    }

    static void Main()
    {
        List<string> history = LoadHistory();
        HandleUserChoice(history);
        SaveHistory(history);
    }
}