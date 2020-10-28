using ChordApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChordApi.DTO
{
    public class SongInputDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Title name should be shorter. Max 50 characters")]
        public string Title { get; set; }

        [Url]
        public string UltimateGuitarUri { get; set; }

        [Required]
        public virtual ArtistInputDto Artist { get; set; }
        [MinLength(1, ErrorMessage = "You should at least submit one chord")]
        public virtual List<ChordInputDto> Chords { get; set; }
    }
}
