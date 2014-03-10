using System;

namespace MusicPlayer
{
    class Song 
    {
        public Guid Id { get; private set; }

        public Song()
        {
            Id=Guid.NewGuid();
        }

        public string SongName { get; set; }
        public TimeSpan SongTime { get; set; }
        public string FilePass { get; set; }
    }
}
