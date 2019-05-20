using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            string report = null;
            int i;
            List<Song> RowCol = new List<Song>();
        try
        {
            if (File.Exists($"SamplePlaylist.txt") == false)
            {
                Console.WriteLine("This text doesn't exist. Try again. ");
            }
            else
            {
                StreamReader sr = new StreamReader($"SamplePlaylist.txt");
                i = 0;
                string line = sr.ReadLine();
                while ((line = sr.ReadLine()) != null)
                {
                    i = i + 1;
                    try
                    {
                        string[] strings = line.Split('\t');
                        if (strings.Length < 8)
                        {
                            Console.Write("This record doesn't comntain correct number of data elements. Try again");
                            Console.WriteLine($"Row {i} contains {strings.Length} values. It should contain 8.");
                            break;
                        }
                        else
                        {
                            Song dataTemp = new Song((strings[0]), (strings[1]), (strings[2]), (strings[3]), Int32.Parse(strings[4]), Int32.Parse(strings[5]));
                                RowCol.Add(dataTemp);
                        }
                    }
                    catch
                    {
                        Console.Write("Errors have ocurred reading lines from data file. Try again");
                        break;
                    }
                }
                sr.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("this playlist data file can't be opened.");
        }

        try
        {
            Song[] songs = RowCol.ToArray();
            using (StreamWriter write = new StreamWriter("MusicPlayer.txt"))
                {
                    write.WriteLine("Music Player");
                    write.Writeline("");

                    //1
                    var SongsPlays = from song in songs where song.Plays >= 200 select song;
                    report += "song plays >= 200: \n";
                    foreach (Song song in SongsPLays)
                    {
                    report += song + "\n";
                    }
                    //2
                    var AlternativeGenre = from song in songs where song.Genre == "Alternative" select song;
                    i = 0;
                    foreach (Song song in AlternativeGenre)
                    {
                    i++;
                    }
                    report += $"songs in genre of Alternative: {i}"\n";
                    //3
                    var HipHopGenre = from song in songs where song.Genre == "Hip-Hop/Rap" select song;
                    i = 0;
                    foreach (Song song in HipHopGenre)
                    {
                    i++;
                    }
                    report += $"Number of Hip-Hop/Rap songs: {i}\n"; 
                    //4   
                    var FishbowlAlbumSongs = song in songs where song.Album == "Welcome to the fishbowl" select song;
                    report += "Songs from the album Welcome to the Fishbowl: \n";
                    foreach (Song song in FishbowlAlbumSongs)
                    {
                    report += song + "\n";
                    }
                    //5
                    var Songs1970 = from song in songs where song.Year < 1970 select song;
                    report += "Songs from before 1970: \n";
                    foreach (Song song in Songs1970)
                    {
                    report += song + "\n";
                    }
                    //6
                    var characters85 = song in songs where song.Name.Length > 85 select song.Name;
                    report += "Song names longer than 85 characters: \n";
                    foreach (String name in characters85)
                    {
                    report += name + "\n";
                    }
                    //7
                    var LongSong = from song in songs orderby song.Time descending select song;
                    report += "Longest song: \n";
                    report += LongSong.First();
        
                    write.Write(report);

                    write.Close();
                }
                Console.WriteLine("Playlist file is created");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Report file can't be open or written to. Please try again");
            }
            Console.ReadLine();
        }
    }
}
namespace MusicPlayerAnalyzer
{
    public class MusicStats
    {
        public String Name;
        public String Artist;
        public String Album;
        public String Genre;
        public int Size;
        public int Time;
        public int Year;
        public int Plays;

        public MusicStats(String name, String artist, String album, String genre, int size,
     int time, int year, int plays)
        {
            Name = name;
            Artist = artist;
            Album = album;
            Genre = genre;
            Size = size;
            Time = time;
            Year = year;
            Plays = plays;

        }
    }
}
        override public string ToString()
        {
            return String.Format("Name: {0}, Artist: {1}, Album: {2}, Genre: {3}, Size: {4}, Time: {5}, Year: {6}, Plays: {7}", Name, Artist, Album, Genre, Size, Time, Year, Plays);
        }

    }













