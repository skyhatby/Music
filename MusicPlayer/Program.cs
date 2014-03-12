using System;

namespace MusicPlayer
{
    class Program
    {
        static void Main()
        {
            var time = new TimeSpan(00, 5, 43);
            var song1 = new Song { FilePass = "f:/music/star.mp3", SongName = "Star", SongTime = time };
            var song2 = new Song { FilePass = "f:/music/road.mp3", SongName = "Road", SongTime = time };
            var song3 = new Song { FilePass = "f:/music/road.mp3", SongName = "Road1", SongTime = time };
            var song4 = new Song { FilePass = "f:/music/road.mp3", SongName = "Road2", SongTime = time };
            var pl = new PlayList {PlayListName = "PlayList"};
            pl.AddSong(song1);
            pl.AddSong(song2);
            pl.AddSong(song3);
            pl.AddSong(song4);
            pl.Songs.Clear();
            Console.WriteLine(pl);
            pl.ShuffleSongs();
            Console.WriteLine(pl);
            Console.ReadKey();
        }
    }
}
