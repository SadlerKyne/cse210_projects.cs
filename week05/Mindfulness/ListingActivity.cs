using System.Runtime.CompilerServices;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are some of your favorite memories?",
        "What are some things you are grateful for?",
        "What are some of your goals for the future?"
    };

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by listing them out. Take a moment to think about the following prompts and write down your responses.";
    }
    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
    protected override void PerformActivity()
    {
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine("You may begin in:");
        ShowCountDown(5);

        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrEmpty(response))
            {
                responses.Add(response);
                Console.WriteLine($"You have listed {responses.Count} responses so far.");
            }
            else
            {
                Console.WriteLine("Please enter a valid response.");
            }
        }
    }
}