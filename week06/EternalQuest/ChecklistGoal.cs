public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (!IsCompleted())
        {
            _amountCompleted++;
            if (_amountCompleted >= _target)
            {
                return GetPoints() + _bonus;
            }
            return GetPoints();
        }
        return 0;
    }

    public override bool IsCompleted()
    {
        return _amountCompleted >= _target;
    }

    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }
    public string GetDetailsString()
    {
        string status = IsCompleted() ? "Completed" : "Incomplete";
        return $"{GetName()} ({GetDescription()}) - {status}: {_amountCompleted}/{_target} completed, Bonus: {_bonus} points";
    }
    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetName()},{GetDescription()},{GetPoints()},{_amountCompleted},{_target},{_bonus}";
    }
}