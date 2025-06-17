using System;

class Program
{
    static void Main(string[] args)
    {
        var activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2022, 11, 3), 30, 3.0));
        activities.Add(new Cycling(new DateTime(2022, 11, 4), 45, 20.0));
        activities.Add(new Swimming(new DateTime(2022, 11, 5), 60, 40));

        Console.WriteLine("--- Fitness Activity Log ---");
        Console.WriteLine("Date       | Activity   | Minutes | Distance (mi) | Speed (mi/h) | Pace (min/mi)");
        Console.WriteLine("-----------|------------|---------|----------------|---------------|----------------");

        foreach (Activity activity in activities)
        {
            string summary = activity.GetSummary();
            Console.WriteLine(summary);
        }
    }
}