using AccountingOfAchievements.Domain;
using AccountingOfAchievements.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AccountingOfAchievements.Infrastructure.Migrations;

public class PortfolioRepository
{
    private readonly Context _context;
    public Context UnitOfWork
    {
        get { return _context; }
    }
    public PortfolioRepository(Context context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }


    // добавление и удаление 
    public async Task<Portfolio> AddAsync(Portfolio portfolio)
    {
        _context.Portfolios.Add(portfolio);
        await _context.SaveChangesAsync();
        return portfolio;
    }
    public async Task DeleteAsync(Portfolio portfolio)
    {
        _context.Portfolios.Remove(portfolio);
        await _context.SaveChangesAsync();
    }


    // гетеры
    public async Task<Portfolio?> GetByIdAsync(Guid id)
    {
        return await _context.Portfolios.FindAsync(id);
    }
    public async Task<List<Portfolio>> GetAllAsync()
    {
        return await _context.Portfolios.OrderBy(o => o.UserName).ToListAsync();
    }
  



    // обновление
    public async Task UpdateAsync(Portfolio portfolio)
    {
        var existPortfolio = GetByIdAsync(portfolio.Id).Result;
        if (existPortfolio != null)
        {
            // обновление полей
            _context.Entry(existPortfolio).CurrentValues.SetValues(portfolio);

            // замена портфолио в достижении в листе достижений портфолио
            foreach (var exAchiv in existPortfolio.Achievements)
            {
                _context.Entry(exAchiv.Portfolio).CurrentValues.SetValues(portfolio);
            }
        }

        await _context.SaveChangesAsync();
    }

    //Удалить из портфолио
    public async Task DeleteFromPortfolio(Portfolio portfolio, Achievement achievement)
    {
        portfolio.RemovePersonalAchiv(achievement);
        await _context.SaveChangesAsync();
    }
    // Длобавить в портфолио
    public async Task AddToPortfolio(Portfolio portfolio, Achievement achievement)
    {
        if (!portfolio.Achievements.Contains(achievement))
        {
            portfolio.AddPersonalAchiev(achievement);
            await _context.SaveChangesAsync();
        }
    }


    public void ChangeTrackerClear()
    {
        _context.ChangeTracker.Clear();
    }
}
