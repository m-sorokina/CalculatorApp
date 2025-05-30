// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.CompilerServices;

List<string> operations = [ "+", "-", "*", "/", "^" ];

bool isContinue = true;
bool usePreviousResult = false;
double previousResult = 0;
do
{
    Compute();
    Console.Write("Do you want to continue? (y/n): ");
    isContinue = Console.ReadLine()?.Trim().ToLower() == "y";
    if (isContinue)
    {
        Console.Write("Would you like to you use previous result for further computing? (y/n): ");
        usePreviousResult = Console.ReadLine()?.Trim().ToLower() == "y";
    }
}
while (isContinue);

void Compute()
{
    double firstNumber = 0;
    if (usePreviousResult)
    {
        Console.WriteLine($"Enter first number: {previousResult}");
        firstNumber = previousResult;
    }
    else
    {
        firstNumber = GetNumber("Enter first number: ");
    }

    Console.Write($"Enter operation ({string.Join(", ", operations)}): ");
    string operation = Console.ReadLine();
    while (!operations.Contains(operation))
    {
        Console.Write($"Invalid operation. Please enter one of ({string.Join(", ", operations)}): ");
        operation = Console.ReadLine();
    }

    double secondNumber = GetNumber("Enter second number: ");

    while (operation == "/" && secondNumber == 0)
    {
        secondNumber = GetNumber("Division by zero is not allowed. Please enter new number: ");

    }

    double result = GetResult(firstNumber, secondNumber, operation);
    Console.WriteLine($"{firstNumber} {operation} {secondNumber} = {result}");

    previousResult = result;

}
double GetNumber(string prompt) 
{
    bool isCorrect;
    double number = 0;
    do 
    {
        Console.Write(prompt);
        isCorrect = double.TryParse(Console.ReadLine(), out number);
        if (!isCorrect)
        { 
        prompt = "Invalid input. Please enter a valid number: ";
        }
    }
    while (!isCorrect);
    return number;
}

double GetResult(double a, double b, string op) => op switch
{
    "+" => a + b,
    "-" => a - b,
    "*" => a * b,
    "/" => a / b,
    "^" => Math.Pow(a, b),
    _ => throw new InvalidOperationException("Invalid operation")

};



