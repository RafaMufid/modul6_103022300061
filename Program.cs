// See https://aka.ms/new-console-template for more information

using System.Collections;
using System.Diagnostics;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        Random randomId = new Random();
        this.id = randomId.Next(10000, 99999);
        this.title = title;
        this.playCount = playCount;
    }

    public void IncreasePlayCount(int count)
    {
        try
        {
            checked
            {
                this.playCount += count;
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("[ERROR] Play count melebihi batas integer!");
            Console.WriteLine(ex.Message);
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID: {this.id}");
        Console.WriteLine($"Title: {this.title}");
        Console.WriteLine($"Play Count: {this.playCount}");
    }

    public int getPlayCount()
    {
        return this.playCount;
    }

    public string getTitle()
    {
        return this.title;
    }
}

class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    private string username;

    public SayaTubeUser(string username)
    {
        Random randomId = new Random();
        this.id = randomId.Next(10000, 99999);
        this.uploadedVideos = new List<SayaTubeVideo>();
        this.username = username;
    }

    public int GetTotalVideoPlayCount()
    {
        int totalPlayCount = 0;
        foreach (var video in uploadedVideos)
        {
             totalPlayCount += video.getPlayCount();
            
        }
        return totalPlayCount;
    }

    public void AddVideo(SayaTubeVideo video)
    {
        uploadedVideos.Add(video);
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine($"User {this.username}");
        for(int i = 0; i < uploadedVideos.Count; i++)
        {
            Console.WriteLine("Video " + (i+1) + " judul: " + uploadedVideos[i].getTitle());
        }
    }
}

class Program
{
    public static void Main()
    {
        SayaTubeVideo video1 = new SayaTubeVideo("Review Film LoTR: The Fellowship of the Rings");
        video1.IncreasePlayCount(3);
        
        SayaTubeVideo video2 = new SayaTubeVideo("Review Film LoTR: The Two Towers");
        video2.IncreasePlayCount(3);
        
        SayaTubeVideo video3 = new SayaTubeVideo("Review Film LoTR: The Return of the Kings");
        video3.IncreasePlayCount(3);
        
        SayaTubeVideo video4 = new SayaTubeVideo("Review Film The Hobbit: Unexpected Journey");
        video4.IncreasePlayCount(3);
        
        SayaTubeVideo video5 = new SayaTubeVideo("Review Film The Hobbit: The Desolation of Smaug");
        video5.IncreasePlayCount(3);
        
        SayaTubeVideo video6 = new SayaTubeVideo("Review Film The Hobbit: The Battle of the Five Armies");
        video6.IncreasePlayCount(3);

        SayaTubeVideo video7 = new SayaTubeVideo("Review Film Knives Out");
        video7.IncreasePlayCount(3);

        SayaTubeVideo video8 = new SayaTubeVideo("Review Film Murder on Orient Express");
        video8.IncreasePlayCount(3);

        SayaTubeVideo video9 = new SayaTubeVideo("Review Film Death on the Nile");
        video9.IncreasePlayCount(3);

        SayaTubeVideo video10 = new SayaTubeVideo("Review Film A Haunting in Venice");
        video10.IncreasePlayCount(3);

        Console.WriteLine();
        SayaTubeUser user1 = new SayaTubeUser("Rafa Mufid 'Aqila");
        user1.AddVideo(video1);
        user1.AddVideo(video2);
        user1.AddVideo(video3);
        user1.AddVideo(video4);
        user1.AddVideo(video5);
        user1.AddVideo(video6);
        user1.AddVideo(video7);
        user1.AddVideo(video8);
        user1.AddVideo(video9);
        user1.AddVideo(video10);
        user1.PrintAllVideoPlaycount();
    }
}
