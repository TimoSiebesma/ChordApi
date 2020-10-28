using ChordApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChordApi.Data
{
    public class ChordApiContext : DbContext
    {
        public ChordApiContext(DbContextOptions<ChordApiContext> opt) : base(opt)
        {
            //ChangeTracker.LazyLoadingEnabled = true;
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Chord> Chords { get; set; }
        public DbSet<Artist> Artists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
