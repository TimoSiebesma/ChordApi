using ChordApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChordApi.Data.Repositories.Songs
{
    public class SongsRepository : Repository<Song>, ISongsRepository
    {
        public SongsRepository(ChordApiContext context) : base(context)
        {

        }

        public void DeleteSong(Song song)
        {
            if (song == null)
            {
                throw new ArgumentNullException(nameof(song));
            }
            Entities.Remove(song);
        }

        public IEnumerable<Song> GetAllSongs()
        {
            List<List<Chord>> chords = Entities.Select(s => s.Chords.ToList()).ToList();
            List<Artist> artists = Entities.Select(s => s.Artist).ToList();

           return Entities.ToList();
        }

        public IEnumerable<Song> GetAllSongsBasedOnChords(List<Chord> chords)
        {
            List<List<Chord>> chs = Entities.Select(s => s.Chords.ToList()).ToList();
            List<Artist> artists = Entities.Select(s => s.Artist).ToList();

            return Entities.ToList()
                .Where(song => song.Chords
                    .Where(chord => chords
                        .Select(ch => ch.Name).ToList()
                        .Contains(chord.Name))
                    .ToList()
                    .Count() == chords.Count);
        }

        public IEnumerable<Song> GetAllSongsBasedOnName(string name)
        {
            List<List<Chord>> chs = Entities.Select(s => s.Chords.ToList()).ToList();
            List<Artist> artists = Entities.Select(s => s.Artist).ToList();

            return Entities.ToList().Where(e => e.Title.ToLower().Trim().Replace(" ", "") == name.ToLower().Trim().Replace(" ", "")).ToList();
        }

        public Song GetSongById(int id)
        {
            List<List<Chord>> chords = Entities.Select(s => s.Chords.ToList()).ToList();
            List<Artist> artists = Entities.Select(s => s.Artist).ToList();
            return Entities.FirstOrDefault(p => p.Id == id);
        }

        
    }
}
