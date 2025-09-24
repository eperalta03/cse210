//I added a scripture library that randomly selects one and displays it every time the program starts.
//I also added a loop to ask if you want another scripture and repeat the program.
using System;

class Program
{
    static void Main(string[] args)
    {
        List<(Reference reference, string text)> scriptures = new List<(Reference, string)>();
        scriptures.Add((new Reference("Moses", 1, 39), "19 And now, when Moses had said these words, Satan cried with a loud voice, and ranted upon the earth, and commanded, saying: I am the Only Begotten, worship me."));
        scriptures.Add((new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));
        scriptures.Add((new Reference("1 Nefi", 3, 7), "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."));
        scriptures.Add((new Reference("D. & C.", 1, 37, 38), "Search these commandments, for they are true and faithful, and the prophecies and promises which are in them shall all be fulfilled. What I the Lord have spoken, I have spoken, and I excuse not myself; and though the heavens and the earth pass away, my word shall not pass away, but shall all be fulfilled, whether by mine own voice or by the voice of my servants, it is the same."));
        scriptures.Add((new Reference("Malachi", 4, 5, 6), "Behold, I will send you Elijah the prophet before the coming of the great and dreadful day of the Lord: And he shall turn the heart of the fathers to the children, and the heart of the children to their fathers, lest I come and smite the earth with a curse."));
        scriptures.Add((new Reference("Revelations", 20, 12), "And I saw the dead, small and great, stand before God; and the books were opened: and another book was opened, which is the book of life: and the dead were judged out of those things which were written in the books, according to their works."));
        scriptures.Add((new Reference("Mosiah", 2, 41), "And moreover, I would desire that ye should consider on the blessed and happy state of those that keep the commandments of God. For behold, they are blessed in all things, both temporal and spiritual; and if they hold out faithful to the end they are received into heaven, that thereby they may dwell with God in a state of never-ending happiness. O remember, remember that these things are true; for the Lord God hath spoken it."));
        scriptures.Add((new Reference("D. & C.", 42, 11), "Again I say unto you, that it shall not be given to any one to go forth to preach my gospel, or to build up my church, except he be ordained by some one who has authority, and it is known to the church that he has authority and has been regularly ordained by the heads of the church."));


        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorizer Program");
        Console.Write("Do you want to start? Yes/No ");
        string answer = Console.ReadLine();
        string lower = answer.ToLower();

        while (lower != "no")
        {
            Random random = new Random();
            var select = scriptures[random.Next(scriptures.Count)];
            Scripture newScripture = new Scripture(select.reference, select.text);

            Console.Clear();
            Console.WriteLine("Here is your scripture");
            Console.WriteLine(select.reference.GetDisplayText());
            Console.WriteLine(newScripture.GetDisplayText());

            string response = "";
            string responseLower = response.ToLower();
            while (responseLower != "quit")
            {
                Console.Write("Press ENTER to hide words, type quit to finish. ");
                response = Console.ReadLine();
                responseLower = response.ToLower();

                if (response == "")
                {
                    newScripture.HideRandomWords(2);
                    Console.Clear();
                    Console.WriteLine(newScripture.GetDisplayText());
                }

                if (newScripture.IsCompletelyHidden())
                {
                    responseLower = "quit";
                }

            }
            Console.Clear();
            Console.WriteLine("Good job!!!");
            Console.WriteLine("Do you want another scripture? Yes/No ");
            answer = Console.ReadLine();
            lower = answer.ToLower();
        }
        Console.WriteLine("Have a good one");
    }
}