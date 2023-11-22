using AccountingOfAchievements.Domain;
using AccountingOfAchievements.Domain.Model;

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


    // гетер по ID
    public async Task<Portfolio?> GetByIdAsync(Guid id)
    {
        return await _context.Portfolios.FindAsync(id);
    }


    public void ChangeTrackerClear()
    {
        _context.ChangeTracker.Clear();
    }
}
