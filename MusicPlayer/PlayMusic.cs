using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace MusicPlayer
{



    class PlayMusic
    {
        public PlayMusic(PlayList pl)
        {
            PlayList = pl;
        }

        public static PlayList PlayList { get; private set; }

        public event EventHandler<PlayingSongEventArgs> PlayingSong;
        public event EventHandler<PlayingSongEventArgs> TenSecPlaying;

        protected virtual void OnPlayingSong(PlayingSongEventArgs e)
        {
            if (PlayingSong != null) PlayingSong(this, e);
        }

        protected virtual void OnTenSecPlaying(PlayingSongEventArgs e)
        {
            if (TenSecPlaying != null) TenSecPlaying(this, e);
        }

        public void TimerHelper(object data)
        {
            OnTenSecPlaying(new PlayingSongEventArgs((Song)data));
        }

        private TimeSpan getCurrentTimeSpan()
        {
            return new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
        }

        public void Play()
        {
            foreach (var song in PlayList.Songs)
            {
                OnPlayingSong(new PlayingSongEventArgs(song));
                var begin = getCurrentTimeSpan() + song.SongTime;
                var tmr = new Timer(TimerHelper, song, 10000, 10000);
                while (begin >= getCurrentTimeSpan())
                {
                    PlaySong();
                }
                tmr.Dispose();
                Console.WriteLine();
            }
        }



        public void PlaySong()
        {
            Console.Beep();
        }
    }
}
