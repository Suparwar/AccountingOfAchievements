using AccountingOfAchievements.Domain;
using AccountingOfAchievements.Domain.DTO;
using AccountingOfAchievements.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace AccountingOfAchievements.Infrastructure.Migrations;

public class OrganizationsRepository
{
    private readonly Context _context;
    public Context UnitOfWork
    {
        get { return _context; }
    }
    public OrganizationsRepository(Context context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }


    // добавление и удаление организаций
    public async Task<Organization> AddAsync(Organization organization)
    {
        _context.Organizations.Add(organization);
        await _context.SaveChangesAsync();
        return organization;
    }
    public async Task DeleteAsync(Organization organization)
    {
        _context.Organizations.Remove(organization);
        await _context.SaveChangesAsync();
    }


    // гетер
    public async Task<Organization?> GetByIdAsync(Guid id)
    {
        return await _context.Organizations.FindAsync(id);
    }
    public async Task<Organization?> GetByOrgNameAsync(string name)
    {
        return await _context.Organizations.FindAsync(name);
    }
    public async Task<List<Organization>> GetAllAsync()
    {
        return await _context.Organizations.OrderBy(o => o.Name).ToListAsync();
    }


    // обновление
    public async Task UpdateAsync(Organization organization)
    {
        var existOrganization = GetByIdAsync(organization.Id).Result;
        if (existOrganization != null)
        {
            // обновление полей
            _context.Entry(existOrganization).CurrentValues.SetValues(organization);

            // замена Организации в достижении в листе достижений организации
            foreach (var exAchiv in existOrganization.Achievements)
            {
                _context.Entry(exAchiv.IssuedFrom).CurrentValues.SetValues(organization);
            }
        }

        await _context.SaveChangesAsync();
    }


    public void ChangeTrackerClear()
    {
        _context.ChangeTracker.Clear();
    }
}
