using ChordApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChordApi.Data.Repositories.Chords
{
    public class ChordsRepository : Repository<Chord>, IChordsRepository
    {
        public ChordsRepository(ChordApiContext context) : base(context)
        {

        }


    }
}
