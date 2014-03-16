using System;
using System.IO;

namespace MusicPlayer
{
    public class Song : EntityId
    {
        private string _songName;
        public Song()
        {
            Id = Guid.NewGuid();
        }

        public string SongName
        {
            get { return _songName; }
            set
            {
                if (value.Length>256) throw new InvalidDataException("Length must be less that 256");
                _songName = value;
            }
        }
        public TimeSpan SongTime { get; set; }
        public string FilePass { get; set; }

        public override string ToString()
        {
            return SongName + " " + SongTime;
        }
    }
}
