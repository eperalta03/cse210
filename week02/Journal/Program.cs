//I added a list of motivational quotes that will be displayed randomly each time the program runs.
//I also added a counter that counts each time an entry is written and displays it when the program ends.

using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator prompt = new PromptGenerator();
        prompt._prompts.Add("What was the most interesting thing I learned today? ");
        prompt._prompts.Add("What action did I take today that I´m proud of? ");
        prompt._prompts.Add("What can I improve tomorrow to have a more productive day? ");
        prompt._prompts.Add("What made me smile or laugh today? ");
        prompt._prompts.Add("What am I grateful for today? ");
        prompt._prompts.Add("What is a lesson I learned from a mistake today?");
        prompt._prompts.Add("How did I help someone else today?");
        prompt._prompts.Add("What is one goal I want to focus on tomorrow?");

        List<string> motivationalQuotes = new List<string>()
        {
            "Believe in yourself and all that you are.",
            "Every day is a new opportunity to grow.",
            "Small steps every day lead to big results.",
            "Challenges are what make life interesting.",
            "Stay positive, work hard, make it happen.",
            "Your only limit is your mind.",
            "Dream it. Wish it. Do it.",
            "Push yourself, because no one else is going to do it for you.",
            "Great things never come from comfort zones.",
            "The harder you work for something, the greater you'll feel when you achieve it."
        };

        Random random = new Random();
        string quote = motivationalQuotes[random.Next(motivationalQuotes.Count)];
        Console.WriteLine("Motivational Quote: " + quote);
        Console.WriteLine("------------------------------");

        Journal entryList = new Journal();

        string action = "";
        int numEntries = 0;

        while (action != "5")
        {
            Console.WriteLine("Please select one of following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            action = Console.ReadLine();

            if (action == "1")
            {
                Entry entry1 = new Entry();
                entry1._date = DateTime.Now.ToShortDateString();
                entry1._promptText = prompt.GetRandomPrompt();
                Console.WriteLine(entry1._promptText);
                entry1._entryText = Console.ReadLine();

                entryList._entries.Add(entry1);

                numEntries++;
            }

            else if (action == "2")
            {
                entryList.DisplayAll();
            }

            else if (action == "3")
            {
                Console.WriteLine("What is the filename? ");
                string file = Console.ReadLine();

                entryList.LoadFromFile(file);
            }

            else if (action == "4")
            {
                Console.WriteLine("What is the filename? ");
                string file = Console.ReadLine();

                entryList.SaveToFile(file);
            }

            else if (action == "5")
            {
                Console.WriteLine($"You have writen {numEntries} entries so far ");
                Console.WriteLine("Have a good one, bye!");
            }

            else
            {
                Console.WriteLine("Please select a valid action");
            }
        }   
    }
}