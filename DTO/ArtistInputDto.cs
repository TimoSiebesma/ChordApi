using ChordApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChordApi.DTO
{
    public class ArtistInputDto
    {

        [Required]
        [MaxLength(50, ErrorMessage = "Please enter a shorter artist name. Max character = 50")]
        [MinLength(1, ErrorMessage = "Please enter a longer artist name.")]
        public string Name { get; set; }
    }
}
