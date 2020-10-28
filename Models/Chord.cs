using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChordApi.Models
{
    public class Chord
    {
        private string name;

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { 
            get
            {
                return name;
            }
            set 
            {
                name = value.Replace("maj", "").Replace("min", "m");
            } 
        }

        [JsonIgnore]
        public int SongId { get; set; }

        [JsonIgnore]
        public virtual Song Song { get; set; }
    }
}
