using ChordApi.Data.Repositories.Artists;
using ChordApi.Data.Repositories.Chords;
using ChordApi.Data.Repositories.Songs;
using ChordApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChordApi.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChordApiContext _context;

        public ISongsRepository Songs { get; }
        public IChordsRepository Chords { get; }
        public IArtistsRepository Artists { get; }

        public UnitOfWork(ChordApiContext context)
        {
            _context = context;
            Songs = new SongsRepository(context);
            Chords = new ChordsRepository(context);
            Artists = new ArtistsRepository(context);
        }

        public bool CreateSongs(List<Song> songs)
        {
            foreach (var song in songs)
            {
                song.Artist = Artists.GetAll().FirstOrDefault(a => a.Name == song.Artist.Name)
                ?? song.Artist;

                bool distinct = Songs.GetAll()
                    .Select(s => new { s.Title, ArtistName = s.Artist.Name })
                    .Where(s => s.Title == song.Title && s.ArtistName == song.Artist.Name)
                    .Count() == 0;

                if (!distinct)
                {
                    return distinct;
                }
            }

            Songs.AddRange(songs);
            return true;
        }

        public bool CreateSong(Song song)
        {
            song.Artist = Artists.GetAll().FirstOrDefault(a => a.Name == song.Artist.Name)
                ?? song.Artist;

            bool distinct = Songs.GetAll()
                .Select(s => new { s.Title, ArtistName = s.Artist.Name })
                .Where(s => s.Title == song.Title && s.ArtistName == song.Artist.Name)
                .Count() == 0;

            if (distinct)
            {
                Songs.Add(song);
            }

            return distinct;
        }

        public void UpdateSong(Song song)
        {
            //
        }


        public int Complete() => _context.SaveChanges();
        public void Dispose() => _context.Dispose();
    }
}
