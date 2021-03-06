﻿using System;
using System.Threading;

namespace MusicPlayer
{
    class Program
    {
        static void Main()
        {
            var time = new TimeSpan(00, 00, 10);
            var song1 = new Song { FilePass = "f:/music/star.mp3", Name = "Star", SongTime = time };
            var song2 = new Song { FilePass = "f:/music/road.mp3", Name = "Road", SongTime = time };
            var song3 = new Song { FilePass = "f:/music/road.mp3", Name = "Road1", SongTime = time };
            var song4 = new Song { FilePass = "f:/music/road.mp3", Name = "Road2", SongTime = time };
            var pl = new PlayList {Name = "PlayList"};
            pl.AddSong(song1);
            pl.AddSong(song2);
            pl.AddSong(song3);
            pl.AddSong(song4);
            
            Console.WriteLine(pl);
            pl.ShuffleSongs();
            Console.WriteLine(pl);
            var play = new PlayMusic(pl);
            play.PlayingSong += PlayMusic_PlayingSong;
            play.TenSecPlaying += PlayMusic_TenSecPlaying;
            var th = new Thread(play.Play);
            th.Start();
            Thread.Sleep(10000);
            pl.AddSong(song1);
            Console.ReadKey();
        }

        private static void PlayMusic_PlayingSong(object sender, PlayingSongEventArgs e)
        {
            Console.WriteLine("Begin to play : "+e.PlayingSong);
            Console.WriteLine("-------------------");
        }

        private static void PlayMusic_TenSecPlaying(object sender, PlayingSongEventArgs e)
        {
            Console.WriteLine("Now playing: {0}{1}", e.PlayingSong, Environment.NewLine);
        }
    }
}
