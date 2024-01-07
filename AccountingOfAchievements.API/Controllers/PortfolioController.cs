using AccountingOfAchievements.Domain;
using AccountingOfAchievements.Domain.DTO;
using AccountingOfAchievements.Domain.Model;
using AccountingOfAchievements.Infrastructure;
using AccountingOfAchievements.Infrastructure.Migrations;
using AccountingOfAchievements.Infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountingOfAchievements.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PortfolioController : ControllerBase
{
    private readonly Context _context;
    private readonly PortfolioRepository _portfolioRepository;
    private readonly AchievementRepository _AchievementRepository;
    public PortfolioController(Context context)
    {
        _context = context;
        _portfolioRepository = new PortfolioRepository(_context);
        _AchievementRepository = new AchievementRepository(context);
    }




    // GET: api/<PortfolioController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PortfolioDTO>>> GetPortfolios()
    {
        var portfolios = await _portfolioRepository.GetAllAsync();
        return PortfolioDTOMapper.ToDto(portfolios);
    }

    // GET api/<PortfolioController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Portfolio>> GetPortfolio(Guid id)
    {
        var portfolio = await _portfolioRepository.GetByIdAsync(id);
        if (portfolio == null)
        {
            return NotFound();
        }

        return portfolio;
    }





    // POST api/<PortfolioController>
    [HttpPost]
    public async Task<ActionResult<PortfolioDTO>> PostPortfolio(PortfolioDTO portfolioDTO)
    {
        portfolioDTO.Id = new Guid();
        var portfolio = PortfolioDTOMapper.ToEntity(portfolioDTO);
        await _portfolioRepository.AddAsync(portfolio);

        return CreatedAtAction("GetPortfolio", new { id = portfolio.Id }, portfolio);
    }






    // PUT изменить 
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, PortfolioDTO portfolioDTO)
    {
        portfolioDTO.Id = id;

        var portfolio = PortfolioDTOMapper.ToEntity(portfolioDTO);
        await _portfolioRepository.UpdateAsync(portfolio);

        return NoContent();
    }

    // PUT Добавить достижение
    [HttpPut("addAchievementMethod/{portfolioId},{achievementId}")]
    public async Task<IActionResult> PutAddAchivement(Guid achievementId, Guid portfolioId)
    {
        var existPorfolio = _portfolioRepository.GetByIdAsync(portfolioId).Result;
        var existAchievement =  _AchievementRepository.GetByIdAsync(achievementId).Result;
   
        if (existAchievement == null || existPorfolio == null)
        {
            return NotFound();
        }

        _portfolioRepository.AddToPortfolio(existPorfolio, existAchievement);

        return NoContent();
    }

    // PUT Удалить достижение
    [HttpPut("deleteAchievementMethod/{portfolioId},{achievementId}")]
    public async Task<IActionResult> PutDeleteAchivement(Guid achievementId, Guid portfolioId)
    {
        var existAchievement =  _AchievementRepository.GetByIdAsync(achievementId).Result;
        var existPorfolio =  _portfolioRepository.GetByIdAsync(portfolioId).Result;
        if (existAchievement == null || existPorfolio == null)
        {
            return NotFound();
        }

        _portfolioRepository.DeleteFromPortfolio(existPorfolio, existAchievement);

        return NoContent();
    }








    // DELETE api/<PortfolioController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        Portfolio portfolio = await _portfolioRepository.GetByIdAsync(id);
        if(portfolio == null)
        {
            return NotFound();
        }

        await _portfolioRepository.DeleteAsync(portfolio);

        return NoContent();
    }
}
