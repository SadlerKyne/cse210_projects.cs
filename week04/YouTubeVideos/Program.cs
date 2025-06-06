using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("C# Basics", "Master C", 300);
        video1.AddComment("Alice", "Great video!");
        video1.AddComment("Bob", "Very informative, thanks!");
        videos.Add(video1);

        Video video2 = new Video("Python vs C#", "Code Wars", 450);
        video2.AddComment("Charlie", "I prefer Python, but C# is great too.");
        video2.AddComment("Dave", "C# is more powerful for enterprise applications.");
        videos.Add(video2);

        Console.WriteLine("------YouTube Videos:------");
        Console.WriteLine();
        foreach (var video in videos)
        {
            video.DisplayVideoInfo();
            Console.WriteLine();
        }
    }
}