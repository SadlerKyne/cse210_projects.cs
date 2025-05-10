using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string username = PromptUserName();
        int usernumber = PromptUserNumber();
        int usersquare = SquareNumber(usernumber);
        DisplayResult(username, usersquare);
    }
    static void DisplayWelcome() 
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName()
    {
        Console.Write("Please enter your Name: ");
        string name = Console.ReadLine();
        return name;
    }
    static int PromptUserNumber() 
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine();
        int number = int.Parse(input);
        return number;
    }
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name} the square of your number is {square}.");
    }
}