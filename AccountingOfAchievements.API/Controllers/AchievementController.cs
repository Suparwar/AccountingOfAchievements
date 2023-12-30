using AccountingOfAchievements.Domain;
using AccountingOfAchievements.Domain.DTO;
using AccountingOfAchievements.Domain.Model;
using AccountingOfAchievements.Infrastructure.Migrations;
using AccountingOfAchievements.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using AccountingOfAchievements.Infrastructure.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountingOfAchievements.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AchievementController : ControllerBase
{
    private readonly Context _context;
    private readonly AchievementRepository _achievementRepository;

    public AchievementController(Context context)
    {
        _context = context;
        _achievementRepository = new AchievementRepository(context);
    }


    // GET: api/<AchievementController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AchievementDTO>>> GetAchievements()
    {
        var achievements = await _achievementRepository.GetAllAsync();
        var achievmentsDTO = AchievementDTOMapper.ToDto(achievements);
        return achievmentsDTO;
    }

    // GET api/<AchievementController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Achievement>> GetAchievement(Guid id)
    {
        var achievement = await _achievementRepository.GetByIdAsync(id);
        if (achievement == null)
        {
            return NotFound();
        }

        return achievement;
    }




    // POST api/<AchievementController>
    [HttpPost("sport")]
    public async Task<ActionResult<Achievement>> PostSportAchievement(AchievementSportDTO achievementDTO)
    {
        achievementDTO.Id = new Guid();
        var achievement = AchievementSportDTOMapper.ToEntity(achievementDTO);
        await _achievementRepository.AddAsync(achievement, achievementDTO.PortfilioId, achievementDTO.OrganizationId);

        return CreatedAtAction("GetAchievement", new { id = achievement.Id }, achievement);
    }
    [HttpPost("art")]
    public async Task<ActionResult<Achievement>> PostArtAchievement(AchievementArtDTO achievementDTO)
    {
        achievementDTO.Id = new Guid();
        var achievement = AchievementArtDTOMapper.ToEntity(achievementDTO);
        await _achievementRepository.AddAsync(achievement, achievementDTO.PortfilioId, achievementDTO.OrganizationId);

        return CreatedAtAction("GetAchievement", new { id = achievement.Id }, achievement);
    }
    [HttpPost("Academic")]
    public async Task<ActionResult<Achievement>> PostAcademicAchievement(AchievementAcademDTO achievementDTO)
    {
        achievementDTO.Id = new Guid();
        var achievement = AchievementAcademDTOMapper.ToEntity(achievementDTO);
        await _achievementRepository.AddAsync(achievement, achievementDTO.PortfilioId, achievementDTO.OrganizationId);

        return CreatedAtAction("GetAchievement", new { id = achievement.Id }, achievement);
    }



    // DELETE api/<AchievementController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var achievement = await _achievementRepository.GetByIdAsync(id);
        if (achievement == null)
        {
            return NotFound();
        }

        await _achievementRepository.DeleteAsync(achievement);

        return NoContent();
    }

}

