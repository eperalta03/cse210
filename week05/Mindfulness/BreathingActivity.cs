public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        
    }

    public void Run()
    {
        DisplayStartingMessage();

        List<string> breathes = new List<string>();
        breathes.Add("Breathe in...");
        breathes.Add("Now breathe out...");

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = breathes[i];
            Console.Write($"{s} ");

            if (i == 0)
            {
                ShowCountDown(4);
                Console.WriteLine("");
            }
            else if (i == 1)
            {
                ShowCountDown(6);
                Console.WriteLine("");
                Console.WriteLine("");
            }

            i++;
            if (i >= breathes.Count)
            {
                Thread.Sleep(1000);
                i = 0;
            }
        }

        DisplayEndingMessage();
    }
}