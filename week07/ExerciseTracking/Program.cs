using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        List<Activity> activities = new List<Activity>();

        RunningActivity runningActivity = new RunningActivity(30, 100);
        activities.Add(runningActivity);

        CyclingActivity cyclingActivity = new CyclingActivity(45, 15);
        activities.Add(cyclingActivity);

        SwimmingActivity swimmingActivity = new SwimmingActivity(60, 10);
        activities.Add(swimmingActivity);

        foreach(Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
            Console.WriteLine("");
        }
        
    }
}