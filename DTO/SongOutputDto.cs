using ChordApi.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChordApi.DTO
{
    public class SongOutputDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string UltimateGuitarUri { get; set; }

        public virtual ArtistOutputDto Artist { get; set; }
        [JsonIgnore]
        public virtual List<ChordOutputDto> Chords { get; set; }
    }
}
