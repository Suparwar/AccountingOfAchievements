using AccountingOfAchievements.Domain;
using AccountingOfAchievements.Domain.Model;

namespace AccountingOfAchievements.Infrastructure.Migrations;

public class OrganizationsRepository
{
    private readonly Context _context;
    public Context UnitOfWork
    {
        get {  return _context; }
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


    // гетер по ID и name
    public async Task<Organization?> GetByIdAsync(Guid id)
    {
        return await _context.Organizations.FindAsync(id);
    }
    public async Task<Organization?> GetByOrgNameAsync(string name)
    {
        return await _context.Organizations.FindAsync(name);
    }


    // добавление и удаление достижений
    public async Task<Achievement> AddAchievementAsync(Achievement achievement)
    {
        _context.Achievements.Add(achievement);
        await _context.SaveChangesAsync();
        return achievement;
    }
    public async Task DeleteAchievementAsync(Achievement achievement)
    {
        _context.Achievements.Remove(achievement);
        await _context.SaveChangesAsync();
    }

    // обновление
    // ...


    public void ChangeTrackerClear()
    {
        _context.ChangeTracker.Clear();
    }
}
