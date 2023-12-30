using AccountingOfAchievements.Domain.Model;
using AccountingOfAchievements.Infrastructure.Migrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOfAchievements.Infrastructure.Repository;

public class AchievementRepository
{
    private readonly Context _context;
    public Context UnitOfWork
    {
        get { return _context; }
    }
    public AchievementRepository(Context context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }



    // добавление и удаление 
    public async Task<Achievement> AddAsync(Achievement achievement, Guid portfolioId, Guid organizationId)
    {
        if (portfolioId != Guid.Empty)
        {
            var existPorfolio = _context.Portfolios.FindAsync(portfolioId).Result;
            if (existPorfolio != null)
            {
                achievement.Portfolio = existPorfolio;
            }
        }

        if (organizationId != Guid.Empty)
        {
            var existOrganization = _context.Organizations.FindAsync(organizationId).Result;
            if (existOrganization != null)
            {
                achievement.IssuedFrom = existOrganization;
                existOrganization.Achievements.Add(achievement);
            }
        }

        _context.Achievements.Add(achievement);
        await _context.SaveChangesAsync();
        return achievement;
    }
    public async Task DeleteAsync(Achievement achievement)
    {
        _context.Achievements.Remove(achievement);
        await _context.SaveChangesAsync();
    }


    // гетер по ID
    public async Task<Achievement?> GetByIdAsync(Guid id)
    {
        return await _context.Achievements
            .Include(a => a.IssuedFrom)
            .Include(a => a.Portfolio)
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();
    }
    public async Task<List<Achievement>> GetAllAsync()
    {
        return await _context.Achievements
            .Include(a => a.Portfolio)
            .Include(a => a.IssuedFrom)
            .ToListAsync();
    }



    public void ChangeTrackerClear()
    {
        _context.ChangeTracker.Clear();
    }
}
