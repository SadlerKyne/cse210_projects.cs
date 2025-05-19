using System;
using Microsoft.Win32.SafeHandles;

public class Program
{
    public static void Main(string[] args)
    {
        Journal myJournal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool running = true;

        Console.WriteLine("Welcome to your Journal Program!");

        while (running)
        {
            Console.WriteLine("\nPlease select an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string randomPrompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nToday's Prompt: {randomPrompt}");
                Console.Write("Your response: ");
                string response = Console.ReadLine();
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                Entry newEntry = new Entry(date, randomPrompt, response);
                myJournal.AddEntry(newEntry);
                Console.WriteLine("Entry added successfully!");
            }
            else if (choice == "2")
            {
                myJournal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to save (e.g., journal.txt): ");
                string saveFilename = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(saveFilename))
                {
                    myJournal.SaveToFile(saveFilename);
                }
                else
                {
                    Console.WriteLine("Invalid filename. Save cancelled.");
                }
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load (e.g., journal.txt): ");
                string loadFilename = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(loadFilename))
                {
                    myJournal.LoadFromFile(loadFilename);
                }
                else
                {
                    Console.WriteLine("Invalid filename. Load cancelled.");
                }
            }
            else if (choice == "5")
            {
                running = false;
                Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
            }
        }
    }
}