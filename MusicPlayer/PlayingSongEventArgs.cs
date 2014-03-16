using System;

namespace MusicPlayer
{
    public class PlayingSongEventArgs : EventArgs
    {
        public Song PlayingSong;

        public PlayingSongEventArgs(Song song)
        {
            PlayingSong = song;
        }
    }
}
