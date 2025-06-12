public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Starting the breathing activity...");
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            
            TimeSpan timeRemaining = endTime - DateTime.Now;
            int pauseDuration = (int)Math.Min(5, timeRemaining.TotalSeconds);
            if (pauseDuration > 0)
            {
                Console.WriteLine("Breathe in...");
                ShowCountDown(pauseDuration);
            }
            timeRemaining = endTime - DateTime.Now;
            int pauseDurationOut = (int)Math.Min(5, timeRemaining.TotalSeconds);
            if (pauseDurationOut > 0)
            {
                Console.WriteLine("Breathe out...");
                ShowCountDown(pauseDurationOut);
            }
        }
        Console.WriteLine();
    }
    
}