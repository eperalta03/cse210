using System;
using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {
        string response = "";
        while (response != "4")
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine(" 1. Start breathing activity");
            Console.WriteLine(" 2. Start reflecting activity");
            Console.WriteLine(" 3. Start listing activity");
            Console.WriteLine(" 4. Quit");
            Console.Write("Select a choice from the menu: ");
            response = Console.ReadLine();

            Console.Clear();
            if (response == "1")
            {
                BreathingActivity breathingActivity = new BreathingActivity();
                breathingActivity.Run();
            }

            else if (response == "2")
            {
                ReflectingActivity reflectingActivity = new ReflectingActivity();
                reflectingActivity.Run();
            }

            else if (response == "3")
            {
                ListingActivity listingActivity = new ListingActivity();
                listingActivity.Run();
            }

            else if (response == "4")
            {
                Console.WriteLine("Thanks for using the program! Goodbye!");
            }
            
            else
            {
                Console.WriteLine("Invalid choice. Press Enter to try again.");
                Console.ReadLine();
                Console.Clear();
            }
        }
        
    }
}