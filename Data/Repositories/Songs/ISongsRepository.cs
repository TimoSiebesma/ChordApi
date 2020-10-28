using ChordApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChordApi.Data.Repositories.Songs
{
    public interface ISongsRepository : IRepository<Song>
    {
        void DeleteSong(Song song);
        IEnumerable<Song> GetAllSongs();
        IEnumerable<Song> GetAllSongsBasedOnChords(List<Chord> chords);
        IEnumerable<Song> GetAllSongsBasedOnName(string name);
        Song GetSongById(int id);


    }
}
