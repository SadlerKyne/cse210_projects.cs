public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }
    public void Start()
    {
        DisplayPlayerInfo();
        Console.WriteLine("Welcome to the Eternal Quest!");
        while (true)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Add a new goal");
            Console.WriteLine("2. View all goals");
            Console.WriteLine("3. Save goals");
            Console.WriteLine("4. Load goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ViewGoals();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                Console.WriteLine("Exiting the Eternal Quest. Goodbye!");
                return;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
    public void DisplayPlayerInfo()
    {
        int level = _score / 1000;
        string title = GetLevelTitle(level);
        Console.WriteLine("Player Info:");
        Console.WriteLine($"\nYou have {_score} points.");
        Console.WriteLine($"Current Level: {level} - {title}");
    }
    private string GetLevelTitle(int level)
    {
        if (level < 1) return "Novice";
        if (level < 2) return "Adventurer";
        if (level < 3) return "Hero";
        if (level < 4) return "Champion";
        if (level < 5) return "Legend";
        return "Mythic";
    }
    public void ViewGoals()
    {
        Console.WriteLine("\nGoals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStringRepresentation()}");
        }
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
        }
    }
    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");
        Console.Write("Choose a goal type (1-4): ");
        string choice = Console.ReadLine();

        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter the goal description: ");
        string description = Console.ReadLine();
        Console.Write("Enter the goal points: ");
        int points;
        while (!int.TryParse(Console.ReadLine(), out points) || points < 0)
        {
            Console.Write("Invalid input. Please enter a valid number for points: ");
        }

        if (choice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (choice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (choice == "3")
        {
            Console.Write("How many times does this goal need to be completed? ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Enter the bonus points for completing the checklist goal: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else if (choice == "4")
        {
            _goals.Add(new NegativeGoal(name, description, points));
        }
        else
        {
            Console.WriteLine("Invalid choice. Goal not created.");
            return;
        }
        Console.WriteLine($"Goal '{name}' created successfully!");
    }

    public void SaveGoals()
    {
        Console.WriteLine("What is the filename to save the goals?");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (var goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine($"Goals saved to {filename} successfully!");
    }
    public void LoadGoals()
    {
        Console.WriteLine("What is the filename for the goal file?");
        string filename = Console.ReadLine();
        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            string type = parts[0];
            string name = parts[1];
            string[] values = name.Split(',');

            Goal goal = null;
            if (type == "SimpleGoal")
            {
                goal = new SimpleGoal(values[0], values[1], int.Parse(values[2]));
            }
            else if (type == "EternalGoal")
            {
                goal = new EternalGoal(values[0], values[1], int.Parse(values[2]));
            }
            else if (type == "ChecklistGoal")
            {
                var checklistGoal = new ChecklistGoal(values[0], values[1], int.Parse(values[2]), int.Parse(values[4]), int.Parse(values[3]));
                int completedCount = int.Parse(values[5]);
                for (int j = 0; j < completedCount; j++) { checklistGoal.RecordEvent(); } // Restore progress
                goal = checklistGoal;
            }
            else if (type == "NegativeGoal")
            {
                goal = new NegativeGoal(values[0], values[1], int.Parse(values[2]));
            }
            Console.WriteLine($"\nGoals loaded from {filename} successfully!");
        }
    }
    public void RecordEvent()
    {
        Console.WriteLine("Select a goal to record an event:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ToString()}");
        }
        Console.Write("Enter the goal number: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            int pointsEarned = _goals[goalIndex].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"Event recorded for goal '{_goals[goalIndex].GetName}'. You earned {pointsEarned} points.");
            Console.WriteLine($"Total score: {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal number. Event not recorded.");
        }
    }
}