using ChordApi.Data.Repositories.Artists;
using ChordApi.Data.Repositories.Chords;
using ChordApi.Data.Repositories.Songs;
using ChordApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChordApi.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ISongsRepository Songs { get; }
        IChordsRepository Chords { get; }
        IArtistsRepository Artists { get; }

        bool CreateSong(Song song);
        bool CreateSongs(List<Song> songs);
        void UpdateSong(Song song);
        int Complete();
    }
}
