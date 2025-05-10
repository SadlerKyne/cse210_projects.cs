using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.Write("Enter a list of numbers, type 0 when finished: ");
        string input = Console.ReadLine();
        int num = int.Parse(input);
        int sum = 0;
        int average = 0;
        int largest = 0;
        while (num != 0)
        {
            numbers.Add(num);
            sum += num;
            if (num > largest)
            {
                largest = num;
            }
            Console.Write("Enter number: ");
            input = Console.ReadLine();
            num = int.Parse(input);
            average = sum / numbers.Count;


        }
        Console.WriteLine($"The sum is {sum}");
        Console.WriteLine($"The average is {average}");
        Console.WriteLine($"The largest number is {largest}");

    }
}