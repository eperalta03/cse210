using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video();
        video1._title = "Learning C#";
        video1._author = "Eduardo Peralta";
        video1._lenght = 300;

        video1._comments.Add(new Comment("Matthew", "Nice video!"));
        video1._comments.Add(new Comment("Hyrum", "It helped me a lot"));
        video1._comments.Add(new Comment("Leo", "I need the second part"));

        Video video2 = new Video();
        video2._title = "How to dance bachata";
        video2._author = "Roger G";
        video2._lenght = 450;

        video2._comments.Add(new Comment("Oscar", "Thanks for your video"));
        video2._comments.Add(new Comment("Jessie", "Awesome!!!"));
        video2._comments.Add(new Comment("Sam", "New subscriptor"));

        Video video3 = new Video();
        video3._title = "Tie a tie";
        video3._author = "Fernan";
        video3._lenght = 310;

        video3._comments.Add(new Comment("Dillon", "You are the best"));
        video3._comments.Add(new Comment("Kyle", "Keep it up!!!"));
        video3._comments.Add(new Comment("Everet", "Now I understand it better"));

        Video video4 = new Video();
        video4._title = "The latest sports news";
        video4._author = "JJ Gomez";
        video4._lenght = 560;

        video4._comments.Add(new Comment("Blake", "I liked your video"));
        video4._comments.Add(new Comment("Beckham", "Well done"));
        video4._comments.Add(new Comment("Arthur", "The best channel"));

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);
        videos.Add(video4);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._lenght} seconds");
            Console.WriteLine($"Number of comments: {video.numberOfComments()}");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"{comment._name}: {comment._text}");
            }
        }
    }
}