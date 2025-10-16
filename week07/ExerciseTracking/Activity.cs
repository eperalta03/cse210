public abstract class Activity
{
    private string _name;
    private string _date;
    private int _lengthMinutes;

    public Activity(string name, int lengthMinutes)
    {
        _name = name;
        _lengthMinutes = lengthMinutes;
        _date = DateTime.Now.ToString("dd MMM yyyy");
    }

    public int GetLengthMinutes()
    {
        return _lengthMinutes;
    }
    public abstract double GetDistance();

    public abstract double GetSpeed();

    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{_date} {_name} ({_lengthMinutes} min)- Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}