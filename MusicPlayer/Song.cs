using System;

namespace MusicPlayer
{
    public class Song : EntityId
    {
        public Song()
        {
            Id=Guid.NewGuid();
        }

        public string SongName { get; set; }
        public TimeSpan SongTime { get; set; }
        public string FilePass { get; set; }

        public override string ToString()
        {
            return SongName + " " + SongTime;
        }
    }
}
