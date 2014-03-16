using System;
using System.Threading;

namespace MusicPlayer
{
    class Program
    {
        static void Main()
        {
            var time = new TimeSpan(00, 00, 25);
            var song1 = new Song { FilePass = "f:/music/star.mp3", SongName = "Star", SongTime = time };
            var song2 = new Song { FilePass = "f:/music/road.mp3", SongName = "Road", SongTime = time };
            var song3 = new Song { FilePass = "f:/music/road.mp3", SongName = "Road1", SongTime = time };
            var song4 = new Song { FilePass = "f:/music/road.mp3", SongName = "Road2", SongTime = time };
            var pl = new PlayList {PlayListName = "PlayList"};
            pl.AddSong(song1);
            pl.AddSong(song2);
            pl.AddSong(song3);
            pl.AddSong(song4);
            
            Console.WriteLine(pl);
            //pl.ShuffleSongs();
            var play = new PlayMusic(pl);
            play.PlayingSong += PlayMusic_PlayingSong;
            play.TenSecPlaying += PlayMusic_TenSecPlaying;
            var th = new Thread(play.Play);
            th.Start();
            Thread.Sleep(10000);
            pl.DeliteSong("Star");
            //play.Play();
           // Console.WriteLine(pl);
            Console.ReadKey();
        }

        private static void PlayMusic_PlayingSong(object sender, PlayingSongEventArgs e)
        {
            Console.WriteLine(e.PlayingSong);
            Console.WriteLine("-------------------");
        }

        private static void PlayMusic_TenSecPlaying(object sender, PlayingSongEventArgs e)
        {
            Console.WriteLine("Now playing: {0}",e.PlayingSong);
        }
    }
}
