using AccountingOfAchievements.Domain;
using AccountingOfAchievements.Domain.DTO;
using AccountingOfAchievements.Domain.Model;
using AccountingOfAchievements.Infrastructure;
using AccountingOfAchievements.Infrastructure.Migrations;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountingOfAchievements.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrganizationController : ControllerBase
{
    private readonly Context _context;
    private readonly OrganizationsRepository _organizationsRepository;

    public OrganizationController(Context context)
    {
        _context = context;
        _organizationsRepository = new OrganizationsRepository(context);
    }




    // GET: api/<AchievementController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Organization>>> GetOrganizations()
    {
        var organizations = await _organizationsRepository.GetAllAsync();
        return organizations;
    }

    // GET api/<AchievementController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Organization>> GetOrganization(Guid id)
    {
        var organization = await _organizationsRepository.GetByIdAsync(id);
        if(organization == null)
        {
            return NotFound();
        }

        return organization;
    }




    // POST api/<AchievementController>
    [HttpPost]
    public async Task<ActionResult<Organization>> PostOrganization(OrganizationDTO organizationDTO)
    {
        organizationDTO.Id = new Guid();
        var organization = OrganizationDTOMapper.ToEntity(organizationDTO);
        await _organizationsRepository.AddAsync(organization);

        return CreatedAtAction("GetOrganization", new { id = organization.Id }, organization); 
    }





    // PUT api/<AchievementController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, OrganizationDTO organizationDTO)
    {
        organizationDTO.Id = id;

        var organization = OrganizationDTOMapper.ToEntity(organizationDTO);
        await _organizationsRepository.UpdateAsync(organization);

        return NoContent();
    }



    // DELETE api/<AchievementController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var organization = await _organizationsRepository.GetByIdAsync(id);
        if(organization == null)
        {
            return NotFound();
        }

        await _organizationsRepository.DeleteAsync(organization);

        return NoContent();
    }
}
