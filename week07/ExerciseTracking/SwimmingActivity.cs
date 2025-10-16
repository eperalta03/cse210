public class SwimmingActivity : Activity
{
    private int _laps;

    public SwimmingActivity(int lengthMinutes, int laps) : base("Swimming", lengthMinutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 0.05;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetLengthMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthMinutes() / GetDistance();
    }
}
