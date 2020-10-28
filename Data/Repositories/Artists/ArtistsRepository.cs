using ChordApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChordApi.Data.Repositories.Artists
{
    public class ArtistsRepository : Repository<Artist>, IArtistsRepository
    {
        public ArtistsRepository(ChordApiContext context) : base(context)
        {

        }


    }
}
