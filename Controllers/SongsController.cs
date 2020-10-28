using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ChordApi.Data.UnitOfWork;
using ChordApi.DTO;
using ChordApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ChordApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SongsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<SongOutputDto>> GetAllSongs()
        {
            var songs = _unitOfWork.Songs.GetAllSongs();

            return Ok(_mapper.Map<IEnumerable<SongOutputDto>>(songs));
        }

        [HttpGet("{id:int}", Name ="GetSongById")]
        public ActionResult<SongOutputDto> GetSongById(int id)
        {
            var song = _unitOfWork.Songs.GetSongById(id);

            if (song != null)
            {
                return Ok(_mapper.Map<SongOutputDto>(song));
            }

            return NotFound();
        }

        [HttpGet("{name}")]
        public ActionResult<IEnumerable<SongOutputDto>> GetSongsByName(string name)
        {
            var songs = _unitOfWork.Songs.GetAllSongsBasedOnName(name);

            if (songs.Any())
            {
                return Ok(_mapper.Map<IEnumerable<SongOutputDto>>(songs));
            }

            return NotFound();
        }

        [HttpGet("Chords/{names}")]
        public ActionResult<IEnumerable<SongOutputDto>> GetAllSongsByChords(string names)
        {
            IEnumerable<ChordInputDto> chordsNames = names
                .Split(',')
                .Select(sc => new ChordInputDto { Name = sc.Trim() })
                .Distinct();

            if (!TryValidateModel(chordsNames, nameof(IEnumerable<ChordInputDto>)))
            {
                return ValidationProblem();
            }

            var chords = _mapper.Map<IEnumerable<Chord>>(chordsNames).ToList();
            var songs = _unitOfWork.Songs.GetAllSongsBasedOnChords(chords);
            return Ok(_mapper.Map<IEnumerable<SongOutputDto>>(songs));
        }


        [HttpPost("")]
        public ActionResult<SongInputDto> CreateSong(SongInputDto songCreateDto)
        {
            var songModel = _mapper.Map<Song>(songCreateDto);
            bool success = _unitOfWork.CreateSong(songModel);

            if (!success)
            {
                return ValidationProblem("Song is already in database", "Song", 303);
            }

            _unitOfWork.Complete();

            var songReadDto = _mapper.Map<SongOutputDto>(songModel);

            return CreatedAtRoute(nameof(GetSongById), new { songReadDto.Id }, songReadDto);
        }

        [HttpPost("List")]
        public ActionResult<SongInputDto> CreateSongs(List<SongInputDto> songCreateDtos)
        {
            var songModels = _mapper.Map<List<Song>>(songCreateDtos);
            bool success = _unitOfWork.CreateSongs(songModels);

            if (!success)
            {
                return ValidationProblem("One of the songs is already in database", "IEnumerable<Song>", 303);
            }

            _unitOfWork.Complete();

            return Ok(_mapper.Map<IEnumerable<SongOutputDto>>(songModels));
        }

        //PUT api/chords/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateSong(int id, SongInputDto songInputDto)
        {
            var songModelFromRepo = _unitOfWork.Songs.GetSongById(id);

            if (songModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(songInputDto, songModelFromRepo);
            _unitOfWork.UpdateSong(songModelFromRepo);
            _unitOfWork.Complete();

            return NoContent();
        }

        //PATCH api/song/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialSongUpdate(int id, JsonPatchDocument<SongInputDto> patchDoc)
        {
            var songModelFromRepo = _unitOfWork.Songs.GetSongById(id);

            if (songModelFromRepo == null)
            {
                return NotFound();
            }

            var songToPatch = _mapper.Map<SongInputDto>(songModelFromRepo);
            patchDoc.ApplyTo(songToPatch, ModelState);

            if (!TryValidateModel(songToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(songToPatch, songModelFromRepo);
            _unitOfWork.UpdateSong(songModelFromRepo);
            _unitOfWork.Complete();

            return NoContent();
        }

        //DELETE api/commands/id
        [HttpDelete("{id}")]
        public ActionResult<SongInputDto> DeleteSong(int id)
        {
            var commandModelFromRepo = _unitOfWork.Songs.GetSongById(id);

            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _unitOfWork.Songs.DeleteSong(commandModelFromRepo);
            _unitOfWork.Complete();

            return NoContent();
        }
    }
}
