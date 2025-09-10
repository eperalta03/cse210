using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
        string answer = "yes";
        while (answer == "yes")
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 101);

            int guesses = 0;
            int guess = -1;
            while (guess != number)
            {
                Console.Write("What is your guess? ");
                string userGuess = Console.ReadLine();
                guess = int.Parse(userGuess);

                if (guess == number)
                {
                    Console.WriteLine("You guessed it!");
                }
                if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
                else if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
                guesses++;
            }

            Console.WriteLine($"Total guesses: {guesses}");
            Console.Write("Do you want to play again? ");
            answer = Console.ReadLine();
        } 
    }
}