public abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected int GetMinutes()
    {
        return _minutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        string dateStr = _date.ToString("dd MMM yyyy");
        string activityType = GetType().Name;

        return $"{dateStr} {activityType} ({_minutes} min): " +
               $"Distance: {GetDistance():F2} miles, " +
               $"Speed: {GetSpeed():F2} mph, " +
               $"Pace: {GetPace():F2} min/mile";
    }
}