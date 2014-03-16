using System;

namespace MusicPlayer
{
    public class Song : EntityId
    {
        public Song()
        {
            Id = Guid.NewGuid();
        }
        public TimeSpan SongTime { get; set; }
        public string FilePass { get; set; }

        public override string ToString()
        {
            return _name + " " + SongTime;
        }
    }
}
