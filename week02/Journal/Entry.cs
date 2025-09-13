public class Entry
{
    public string _date = "";
    public string _promptText = "";

    public string _entryText = "";

    public void DisplayEntry()
    {
        Console.WriteLine($"{_date} - Prompt: {_promptText}");
        Console.WriteLine(_entryText);
        Console.WriteLine("--------------------------------");
    }
}