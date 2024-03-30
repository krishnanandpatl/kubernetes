using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using platformservice.Data;
using platformservice.Dtos;
using platformservice.Models;

namespace platformservice.Controller
{
    [ApiController]
    [Route("api/platform")]
    public class PlatformController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlatformRepo _platformRepo;

        public PlatformController(IMapper mapper, IPlatformRepo platformRepo)
        {
            _mapper = mapper;
            _platformRepo = platformRepo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            Console.WriteLine("--> Getting Platforms....");

            var platformItem = _platformRepo.GetAllPlatform();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
        }
        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var platformItem = _platformRepo.GetPlatformById(id);
            if (platformItem != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platformItem));
            }

            return NotFound();
        }
        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(CreatePlatformDto createPlatformDto)
        {
            var platformModel = _mapper.Map<Platform>(createPlatformDto);
            _platformRepo.CreatePlatform(platformModel);
            _platformRepo.SaveChanges();

            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
        }
    }
}