using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChordApi.DTO;
using ChordApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChordApi.Profiles
{
    public class ChordsProfile : Profile
    {
        public ChordsProfile()
        {
            CreateMap<Song, SongOutputDto>();
            CreateMap<SongInputDto, Song>();
            CreateMap<Song, SongInputDto>();

            CreateMap<Chord, ChordOutputDto>();
            CreateMap<ChordInputDto, Chord>();
            CreateMap<Chord, ChordInputDto>();

            CreateMap<Artist, ArtistOutputDto>();
            CreateMap<ArtistInputDto, Artist>();
            CreateMap<Artist, ArtistInputDto>();
        }
    }
}
