using System;
using System.Threading;

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
            try
            {
                foreach (var song in PlayList.Songs)
                {
                    OnPlayingSong(new PlayingSongEventArgs(song));
                    PlayingProcess(song);
                }
            }
            catch (InvalidOperationException)
            {
                Play();
            }
            
        }

        private void PlayingProcess(Song song)
        {
            var begin = getCurrentTimeSpan() + song.SongTime;
            var tmr = new Timer(TimerHelper, song, 10000, 10000);
// ReSharper disable once LoopVariableIsNeverChangedInsideLoop
            while (begin >= getCurrentTimeSpan()) PlaySong();
            tmr.Dispose();
        }


        private static void PlaySong()
        {
            Console.Beep();
        }
    }
}
