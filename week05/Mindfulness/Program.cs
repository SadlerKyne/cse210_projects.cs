using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness App!");
            Console.WriteLine("Please select an activity:");
            Console.WriteLine(" 1. Breathing Activity");
            Console.WriteLine(" 2. Reflection Activity");
            Console.WriteLine(" 3. Start Listing Activity");
            Console.WriteLine(" 4. Exit");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Activity breathingActivity = new BreathingActivity();
                breathingActivity.Run();
            }
            else if (choice == "2")
            {
                ReflectionActivity reflectionActivity = new ReflectionActivity();
                reflectionActivity.Run();
            }
            else if (choice == "3")
            {
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.Run();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Thank you for using the Mindfulness App. Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
            }

            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}