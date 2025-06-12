
public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity()
    {
        _name = " ";
        _description = " ";
    }

    public void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} Activity!");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        while (true)
        {
            Console.Write("How long, in seconds, would you like to do this activity ? ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out _duration) && _duration > 0)
            {
                break;
            }
            else
            {
                Console.WriteLine("Please enter a valid positive number.");
            }
        }
        Console.Clear();
        Console.WriteLine($"Get ready to begin the {_name} Activity!");
        ShowSpinner(5);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine($"Well done! You have completed another {_name} Activity!");
        ShowSpinner(5);
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine("\r \r");
    }
    public void ShowSpinner(int seconds)
    {
        List<string> spinner = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i = (i + 1) % spinner.Count;
        }
    }

    public void Run()
    {
        DisplayStartMessage();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected abstract void PerformActivity();


}