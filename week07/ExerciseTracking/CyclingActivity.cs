public class CyclingActivity : Activity
{
    private double _speed;

    public CyclingActivity(int lengthMinutes, double speed) : base("Cycling", lengthMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * (GetLengthMinutes() / 60.0);
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }
}