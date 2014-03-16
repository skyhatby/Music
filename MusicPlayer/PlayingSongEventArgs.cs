using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
