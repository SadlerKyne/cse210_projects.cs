using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference1 = new Reference("Isaiah", 41, 10);
        string text1 = "So do not fear, for I am with you; do not be dismayed, for I am your God. I will strengthen you and help you; I will uphold you with my righteous right hand.";
        Scripture scripture1 = new Scripture(reference1, text1);

        string userInput = "";
        while (userInput.ToLower() != "quit")
        {
            Console.Clear();
            Console.WriteLine("Scripture Memorizer");
            Console.WriteLine("-------------------");
            Console.WriteLine(scripture1.GetDisplayText());
            Console.WriteLine("\nPress Enter to continue or 'quit' to finish.");
            userInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                scripture1.HideRandomWord(2);
                if (scripture1.IsCompletelyHidden())
                {
                    Console.Clear();
                    Console.WriteLine("Scripture Memorizer");
                    Console.WriteLine("-------------------");
                    Console.WriteLine(scripture1.GetDisplayText());
                    Console.WriteLine("\nCongratulations! You have memorized the scripture!");
                    break;
                }
            }
            else if (userInput.ToLower() == "quit")
            {
                Console.WriteLine("Exiting the Scripture Memorizer. Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid input. Please press Enter to continue or type 'quit' to exit.");
            }
        }
    }
}