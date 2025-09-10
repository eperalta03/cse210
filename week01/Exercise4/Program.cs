using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number = 1;
        int maxNumber = 0;
        while (number != 0)
        {
            Console.Write("Enter number: ");
            string userNumber = Console.ReadLine();
            number = int.Parse(userNumber);
            if (number != 0)
            {
                numbers.Add(number);
                
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }
        }

        int sum = 0;
        foreach (int n in numbers)
        {
            sum += n;
        }
        Console.WriteLine($"The sum is: {sum}");

        int len = numbers.Count;
        int average = sum / len;
        Console.WriteLine($"The average is: {average}");

        Console.WriteLine($"The largest number is: {maxNumber}");

        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}