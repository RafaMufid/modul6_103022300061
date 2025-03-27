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
        Debug.Assert(!string.IsNullOrEmpty(title), "Judul video tidak berupa null");
        Debug.Assert(title.Length <= 200, "Judul video memiliki panjang maksimal 200 karakter");

        Random randomId = new Random();
        this.id = randomId.Next(10000, 99999);
        this.title = title;
        this.playCount = playCount;
    }

    public void IncreasePlayCount(int count)
    {
        Debug.Assert(count <= 25000000, "Penambahan play count maksimal 25.000.000 per panggilan method-nya");
        Debug.Assert(count >= 0, "Input play count tidak berupa bilangan negatif");
        
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
        Debug.Assert(!string.IsNullOrEmpty(username), "Judul video tidak berupa null");
        Debug.Assert(username.Length <= 100, "Judul video memiliki panjang maksimal 100 karakter");

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
            Debug.Assert(totalPlayCount <= int.MaxValue, "Video yang ditambahkan punya playCount yang kurang dari bilangan integer maksimum");

            totalPlayCount += video.getPlayCount();
            
        }
        return totalPlayCount;
    }

    public void AddVideo(SayaTubeVideo video)
    {
        Debug.Assert(video != null, "Video yang ditambahkan tidak berupa null");

        uploadedVideos.Add(video);
    }

    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine($"User {this.username}");
        for(int i = 0; i < 8; i++)
        {
            Console.WriteLine("Video " + (i + 1) + " judul: " + uploadedVideos[i].getTitle());
        }
        Console.WriteLine("Total Play Count: " + GetTotalVideoPlayCount());
    }
}

class Program
{
    public static void Main()
    {
        SayaTubeVideo video1 = new SayaTubeVideo("Review Film LoTR: The Fellowship of the Rings oleh Rafa Mufid 'Aqila");
        video1.IncreasePlayCount(3);
        
        SayaTubeVideo video2 = new SayaTubeVideo("Review Film LoTR: The Two Towers oleh Rafa Mufid 'Aqila");
        video2.IncreasePlayCount(3);
        
        SayaTubeVideo video3 = new SayaTubeVideo("Review Film LoTR: The Return of the Kings oleh Rafa Mufid 'Aqila");
        video3.IncreasePlayCount(3);
        
        SayaTubeVideo video4 = new SayaTubeVideo("Review Film The Hobbit: Unexpected Journey oleh Rafa Mufid 'Aqila");
        video4.IncreasePlayCount(3);
        
        SayaTubeVideo video5 = new SayaTubeVideo("Review Film The Hobbit: The Desolation of Smaug oleh Rafa Mufid 'Aqila");
        video5.IncreasePlayCount(3);
        
        SayaTubeVideo video6 = new SayaTubeVideo("Review Film The Hobbit: The Battle of the Five Armies oleh Rafa Mufid 'Aqila");
        video6.IncreasePlayCount(3);

        SayaTubeVideo video7 = new SayaTubeVideo("Review Film Knives Out oleh Rafa Mufid 'Aqila");
        video7.IncreasePlayCount(3);

        SayaTubeVideo video8 = new SayaTubeVideo("Review Film Murder on Orient Express oleh Rafa Mufid 'Aqila");
        video8.IncreasePlayCount(3);

        SayaTubeVideo video9 = new SayaTubeVideo("Review Film Death on the Nile oleh Rafa Mufid 'Aqila");
        video9.IncreasePlayCount(3);

        SayaTubeVideo video10 = new SayaTubeVideo("Review Film A Haunting in Venice oleh Rafa Mufid 'Aqila");
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
        Console.WriteLine();

        try
        {
            SayaTubeVideo vidLen = new SayaTubeVideo(new string('w', 201));
        }catch(Exception ex)
        {
            Console.WriteLine("[ERROR] " + ex.Message);
        }

        try
        {
            SayaTubeVideo vidNull = new SayaTubeVideo(null);
        }catch(Exception ex){
            Console.WriteLine("[ERROR] " + ex.Message);
        }

        try
        {
            video8.IncreasePlayCount(25000001);
        }catch(Exception ex)
        {
            Console.WriteLine("[ERROR] " + ex.Message);
        }

        try
        {
            video8.IncreasePlayCount(-1);
        }
        catch (Exception ex)
        {
            Console.WriteLine("[ERROR] " + ex.Message);
        }

        try
        {
            SayaTubeUser usnNull = new SayaTubeUser(null);
        }
        catch (Exception ex)
        {
            Console.WriteLine("[ERROR] " + ex.Message);
        }

        try
        {
            SayaTubeUser usnLen = new SayaTubeUser(new string('w', 101));
        }
        catch (Exception ex)
        {
            Console.WriteLine("[ERROR] " + ex.Message);
        }

        try
        {
            SayaTubeUser user2 = new SayaTubeUser("Rafa Mufid 'Aqila");
            user2.AddVideo(null);
        }catch(Exception ex)
        {
            Console.WriteLine("[ERROR] " + ex.Message);
        }
    }
}
