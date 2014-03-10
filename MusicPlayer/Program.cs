using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class Program
    {
        static void Main()
        {
            var time = new TimeSpan(00, 5, 43);
            var song1 = new Song { FilePass = "asd",  SongName = "fgh" , SongTime = time};
            var song2 = new Song { FilePass = "asd", SongName = "fgh", SongTime = time };
            var pl = new PlayList {PlayListName = "asdf"};
            pl.AddSong(song1);
            pl.AddSong(song2);
            //pl.DeliteSong(song1);
            foreach (var song in pl.FindSong(s => s.SongTime==time))
            {
                Console.WriteLine(song.SongName + " " + song.Id);
            }
            //pl.FindSong(s => s.Id>1);

            Console.WriteLine(pl);
            Console.ReadKey();
        }
    }
}
