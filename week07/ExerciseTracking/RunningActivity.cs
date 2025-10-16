public class RunningActivity : Activity
{
    private double _distance;

    public RunningActivity(int lengthMinutes, double distance) : base("Running", lengthMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / GetLengthMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetLengthMinutes() / _distance;
    }
}