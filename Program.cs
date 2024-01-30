using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Simple Calculator");

        while (PerformCalculation()) { }

        Console.WriteLine("Calculator closed.");
    }

    private static bool PerformCalculation()
    {
        double num1, num2;
        string operador;

        if (!TryGetUserInput("Enter the first number: ", out num1))
            return false;

        operador = GetOperator();

        if (!TryGetUserInput("Enter the second number: ", out num2))
            return false;

        double result = Calculate(num1, operador, num2);

        if (!double.IsNaN(result))
            Console.WriteLine($"Result: {result}");
        else
            Console.WriteLine("Invalid operation. Please check your input and try again.");

        return ShouldPerformAnotherOperation();
    }

    private static bool TryGetUserInput(string prompt, out double result)
    {
        result = 0;

        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (!double.TryParse(input, out result))
            {
                Console.WriteLine("Invalid number. Please enter a valid number.");
                continue;
            }

            break;
        }

        return true;
    }

    private static string GetOperator()
    {
        while (true)
        {
            Console.Write("Enter the operator (+, -, *, /): ");
            string input = Console.ReadLine();

            if (IsOperatorValid(input))
                return input;

            Console.WriteLine("Invalid operator. Please enter a valid operator.");
        }
    }

    private static bool IsOperatorValid(string operador)
    {
        return operador == "+" || operador == "-" || operador == "*" || operador == "/";
    }

    private static double Calculate(double num1, string operador, double num2)
    {
        return operador switch
        {
            "+" => num1 + num2,
            "-" => num1 - num2,
            "*" => num1 * num2,
            "/" => (num2 != 0) ? num1 / num2 : double.NaN,
            _ => double.NaN
        };
    }

    private static bool ShouldPerformAnotherOperation()
    {
        while (true)
        {
            Console.Write("Do you want to perform another operation? (Y/N): ");
            string input = Console.ReadLine().Trim().ToUpper();

            if (input == "Y" || input == "N")
                return input == "Y";

            Console.WriteLine("Invalid option. Please enter 'Y' or 'N'.");
        }
    }
}
