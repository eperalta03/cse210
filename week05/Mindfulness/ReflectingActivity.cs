public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>();
    private List<string> _questions = new List<string>();

    private Random _random = new Random();

    public ReflectingActivity() : base("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {

    }

    public void Run()
    {
        _prompts.Add("--- Think of a time when you stood up for someone else. ---");
        _prompts.Add("--- Think of a time when you did something really difficult. ---");
        _prompts.Add("--- Think of a time when you helped someone in need. ---");
        _prompts.Add("--- Think of a time when you did something truly selfless. ---");

        _questions.Add("> Why was this experience meaningful to you?");
        _questions.Add("> Have you ever done anything like this before?");
        _questions.Add("> How did you get started?");
        _questions.Add("> How did you feel when it was complete?");
        _questions.Add("> What made this time different than other times when you were not as successful?");
        _questions.Add("> What is your favorite thing about this experience?");
        _questions.Add("> What could you learn from this experience that applies to other situations?");
        _questions.Add("> What did you learn about yourself through this experience?");
        _questions.Add("> How can you keep this experience in mind in the future?");

        DisplayStartingMessage();

        Console.WriteLine("Consider the following prompt");
        Console.WriteLine("");
        DisplayPrompt();
        Console.WriteLine("");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        string response = Console.ReadLine();

        if (response == "")
        {
            Console.WriteLine("Now ponder of each of the following questions as they related to this experience");
            Console.Write("You may begin in: ");
            ShowCountDown(5);

            Console.Clear();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                DisplayQuestions();
                ShowSpinner(10);
                Console.WriteLine();  
            }
        }

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    public string GetRandomQuestion()
    {
        int index = _random.Next(_questions.Count);
        return _questions[index];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine(GetRandomPrompt());
    }
    
    public void DisplayQuestions()
    {
        Console.WriteLine(GetRandomQuestion());
    }
}