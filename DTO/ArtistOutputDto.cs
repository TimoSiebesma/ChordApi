using ChordApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChordApi.DTO
{
    public class ArtistOutputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
