using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;

namespace PlatformService.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PlatformController : ControllerBase
{
    private readonly IPlatformRepo _repository;
    private readonly IMapper _mapper;

    public PlatformController(IPlatformRepo repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    { 
        Console.WriteLine("--> Gettings Platform");
        var platformItem = _repository.GetAllPlarforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
    }
    
    [HttpGet("{id}",Name ="GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        var platformItem = _repository.GetPlatformById(id);
        if (platformItem != null)
        {
            return Ok(_mapper.Map<PlatformReadDto>(platformItem));
        }

        return NotFound();
    }
    [HttpPost]
    public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
    {
        var platformModel = _mapper.Map<Platform>(platformCreateDto);
        
        _repository.CreatePlatform(platformModel);
        _repository.SaveChanges();

        var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

        return CreatedAtRoute(nameof(GetPlatformById),new {Id = platformReadDto.Id},platformReadDto);
    }

}