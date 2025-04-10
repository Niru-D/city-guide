using AutoMapper;
using CityGuide.Models;
using CityGuide.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CityGuide.Controllers
{
    [ApiController] 
    [Route("api/cities")]
    [Authorize]
    public class CitiesController : ControllerBase
    {
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;
        const int maxPageSize = 20;

        public CitiesController(ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _cityInfoRepository = cityInfoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityWithoutPointsOfInterestDto>>> GetCitites(string? name, string? searchQuery, int pageNumber = 1, int pageSize = 2)
        {
            if (pageSize > maxPageSize)
            {
                pageSize = maxPageSize;
            }

            var (cities, paginationMetadata) = await _cityInfoRepository.GetCitiesAsnyc(name, searchQuery, pageNumber, pageSize);
            Response.Headers.Append("X-Pagination", JsonSerializer.Serialize(paginationMetadata));
            return Ok(_mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cities));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = await _cityInfoRepository.GetCityAsync(id, includePointsOfInterest);
            if (city == null)
            {
                return NotFound();
            }
            if (includePointsOfInterest)
            {
                return Ok(_mapper.Map<CityDto>(city));
            }
            return Ok(_mapper.Map<CityWithoutPointsOfInterestDto>(city));
        }
    }
}
   