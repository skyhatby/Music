using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicPlayer
{
    class PlayList : EntityId
    {
        private readonly ICollection<Song> _songs;

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
        }

        public void AddSong(Song song)
        {
            if (song == null) return;
            Songs.Add(song);
            MusicPlayListTime += song.SongTime;
        }

        public void DeliteSong(string songName)
        {
            if (songName == "") return;
            var song = FindSong(s => s.SongName == songName).FirstOrDefault();
            if (song == null) return;
            _songs.Remove(song);
            MusicPlayListTime -= song.SongTime;
        }

        public override string ToString()
        {
            return Songs.Aggregate(PlayListName + " " + MusicPlayListTime + Environment.NewLine, (current, song) => current + song.ToString() + Environment.NewLine);
        }

        public ICollection<Song> FindSong(Func<Song, bool> f)
        {
            return Songs.Where(f).ToList();
        }

        public void ShuffleSongs()
        {
            var rnd = new Random();
            var newList = new SortedList<int, Song>();
            foreach (var song in Songs)
            {
                newList.Add(rnd.Next(), song);
            }
            Songs.Clear();
            for (var i = 0; i < newList.Count; i++)
            {
                Songs.Add(newList.Values[i]);
            }
        }
    }
}
