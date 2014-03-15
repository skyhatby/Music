using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace MusicPlayer
{
    class PlayMusic
    {
        public PlayMusic(PlayList pl)
        {
            PlayList = pl;
        }

        public static PlayList PlayList { get; private set; }

        public void Play()
        {
            foreach (var song in PlayList.Songs)
            {
                //TODO:1 ое событие
                Console.WriteLine("-------------------");
                TimeSpan begin = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                begin = begin + song.SongTime;
                while (begin > new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second))
                {
                    
                    Console.Write(song.SongName);
                    Thread.Sleep(1000);
                }
            }
        }



        public void Play2(object sender, EventArgs e)
        {
            while (true)
                Console.Write("23");
        }
    }
}
