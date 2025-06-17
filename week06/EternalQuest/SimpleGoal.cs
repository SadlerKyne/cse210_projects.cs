public class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isCompleted = false;
    }

    public override int RecordEvent()
    {
        if (!_isCompleted)
        {
            _isCompleted = true;
            return GetPoints();
        }
        else
        {
            return 0;
        }
    }
    public override bool IsCompleted()
    {
        return _isCompleted;
    }
    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{GetName()},{GetDescription()},{GetPoints()},{_isCompleted}";
    }
}