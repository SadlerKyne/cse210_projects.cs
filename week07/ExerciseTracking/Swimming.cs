public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50.0 / 1000.0 * 0.62;
    }
    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60.0;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        return distance > 0 ? GetMinutes() / distance : 0;
    }
}