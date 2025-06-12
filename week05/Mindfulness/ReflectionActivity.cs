public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    private List<string> _availableQuestions;

    public ReflectionActivity()
    {
        _name = "Reflection";
        _description = "This activity will help you reflect on the good things in your life by asking you a series of thoughtful questions.";
        _availableQuestions = new List<string>(_questions);
    }
    private string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
    private string GetRandomQuestion()
    {
        if (_availableQuestions.Count == 0)
        {
            Console.WriteLine("No more questions available. Starting over.");
            _availableQuestions = new List<string>(_questions);
        }

        Random random = new Random();
        int index = random.Next(_availableQuestions.Count);
        string question = _availableQuestions[index];
        _availableQuestions.RemoveAt(index);
        return question;
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.WriteLine("You may begin in:");
        ShowCountDown(5);

        Console.Clear();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            
            TimeSpan timeRemaining = endTime - DateTime.Now;
            int pauseDuration = (int)Math.Min(10, timeRemaining.TotalSeconds);

            if (pauseDuration > 0)
            {   string question = GetRandomQuestion();
                Console.WriteLine(question);
                ShowSpinner(pauseDuration);
                Console.WriteLine();
            }
            
        }
    }
}