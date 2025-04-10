using AutoMapper;
using CityGuide.Entities;
using CityGuide.Models;
using CityGuide.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityGuide.Controllers
{
    [Route("api/cities/{id}/pointsOfinterest")] 
    [ApiController]
    [Authorize]
    public class PointsOfInterestController : ControllerBase
    {

        private readonly ILogger<PointsOfInterestController> _logger;
        private readonly IMailService _mailService;
        private readonly ICityInfoRepository _cityInfoRepository;
        private readonly IMapper _mapper;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger, IMailService mailService, ICityInfoRepository cityInfoRepository, IMapper mapper)
        {
            _logger = logger;
            _mailService = mailService;
            _cityInfoRepository = cityInfoRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PointOfInterestDto>>> GetPointsOfInterest(int id)
        {
            if (!await _cityInfoRepository.CityExistsAsync(id))
            {
                _logger.LogInformation(
                    $"City with id {id} wasn't found when accessing points of interest.");
                return NotFound();
            }

            var pointsOfInterestForCity = await _cityInfoRepository
                .GetPointsOfInterestForCityAsync(id);

            return Ok(_mapper.Map<IEnumerable<PointOfInterestDto>>(pointsOfInterestForCity));
        }

        [HttpGet("{pointId}", Name = "GetPointOfInterest")]
        public async Task<ActionResult<PointOfInterestDto>> GetPointOfInterest(int id, int pointId)
        {
            if (!await _cityInfoRepository.CityExistsAsync(id))
            {
                return NotFound();
            }

            var pointOfInterest = await _cityInfoRepository
                .GetPointOfInterestForCityAsync(id, pointId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PointOfInterestDto>(pointOfInterest));
        }

        [HttpPost]
        public async Task<ActionResult<PointOfInterestDto>> CreatePointOfInterest(int id, PointOfInterestCreationDto pointOfInterest)
        {
            if (!await _cityInfoRepository.CityExistsAsync(id))
            {
                return NotFound();
            }

            var finalPointOfInterest = _mapper.Map<PointOfInterest>(pointOfInterest);
            await _cityInfoRepository.AddPointOfInterestForCityAsync(id, finalPointOfInterest);
            await _cityInfoRepository.SaveChangesAsync();

            var createdPointOfInterest = _mapper.Map<PointOfInterestDto>(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest", new
            {
                id = id,
                pointId = createdPointOfInterest.Id
            }, createdPointOfInterest);
        }

        [HttpPut("{pointOfInterestId}")]
        public async Task<ActionResult> UpdatePointOfInterest(int id, int pointOfInterestId, PointOfInterestUpdateDto pointOfInterestUpdate)
        {
            if (!await _cityInfoRepository.CityExistsAsync(id))
            {
                return NotFound();
            }

            var pointOfInterestEntity = await _cityInfoRepository.GetPointOfInterestForCityAsync(id, pointOfInterestId);
            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(pointOfInterestUpdate, pointOfInterestEntity);
            await _cityInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{pointOfInterestId}")]
        public async Task<ActionResult> DeletePointOfInterest(int id, int pointOfInterestId)
        {
            if (!await _cityInfoRepository.CityExistsAsync(id))
            {
                return NotFound();
            }

            var pointOfInterestEntity = await _cityInfoRepository.GetPointOfInterestForCityAsync(id, pointOfInterestId);
            if (pointOfInterestEntity == null)
            {
                return NotFound();
            }

            _cityInfoRepository.DeletePointOfInterest(pointOfInterestEntity);
            await _cityInfoRepository.SaveChangesAsync();

            _mailService.sendEmail("Deleted", $"A point of interest has been deleted from city: {id}");
            return NoContent();
        }
    }
}
