using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicPlayer
{
    class PlayList 
    {
        public Guid Id { get; private set; }

        private ICollection<Song> _songs;

        public PlayList()
        {
            _songs = new List<Song>();
            Id = Guid.NewGuid();
        }

        public string PlayListName { get; set; }

        public TimeSpan MusicPlayListTime { get; private set; }

        public virtual ICollection<Song> Songs
        {
            get { return _songs; }
            private set { _songs = value; }
        }

        public void AddSong(Song song)
        {
            if (song == null) return;
            Songs.Add(song);
            MusicPlayListTime += song.SongTime;
        }

        public void DeliteSong(Song song)
        {
            if (song == null) return;
            _songs.Remove(song);
            MusicPlayListTime -= song.SongTime;
        }

        public override string ToString()
        {
            return (PlayListName + " " + MusicPlayListTime);
        }

        public ICollection<Song> FindSong(Func<Song,bool> f)  
        {
            return Songs.Where(f).ToList();
        }

        public ICollection<Song> ShuffleSongs()
        {
            return Songs=Songs.OrderBy(s => s.Id).ToList();
        }
    }
}
