using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChordApi.Models
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        public string UltimateGuitarUri { get; set; }
        public virtual IEnumerable<Chord> Chords { get; set; }
        
    }
}
