public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>();
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {

    }

    public void Run()
    {
        DisplayStartingMessage();

        _prompts.Add("--- Who are people that you appreciate? ---");
        _prompts.Add("--- What are personal strengths of yours? ---");
        _prompts.Add("--- Who are people that you have helped this week? ---");
        _prompts.Add("--- When have you felt the Holy Ghost this month? ---");
        _prompts.Add("--- Who are some of your personal heroes? ---");

        Console.WriteLine("List as many responses as you can to the following prompt:");
        GetRandomPrompt();
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine("");

        GetListFromUser();

        Console.WriteLine();
        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        Random _random = new Random();
        int index = _random.Next(_prompts.Count);
        Console.WriteLine(_prompts[index]);
    }

    public List<string> GetListFromUser()
    {
        List<string> _responses = new List<string>();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            _responses.Add(response);
            _count++;
            
        }
        return _responses;
    }
}