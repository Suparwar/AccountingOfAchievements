using AccountingOfAchievements.Infrastructure;
using AccountingOfAchievements.Domain;
using Microsoft.EntityFrameworkCore;
using AccountingOfAchievements.Domain.Model;
using AccountingOfAchievements.Infrastructure.Repository;
using AccountingOfAchievements.Infrastructure.Migrations;

namespace TestAchievement;

public class TestHelper
{
    private readonly Context _context;

    public TestHelper()
    {
        var contextOptions = new DbContextOptionsBuilder<Context>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test")
                .Options;

        _context = new Context(contextOptions);

        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();


        var achievement = new Achievement();
        achievement.Id = new Guid();

        var portfolioId = new Guid("83f1fe49-f701-4497-b02f-08dc00ca2fa6");
        achievement.Portfolio = new Portfolio
        {
            Id = portfolioId,
            UserName = "Pavel",
            Achievements = { }
        };

        achievement.DateOfReceiving = new DateTime();

        achievement.IssuedFrom = new Organization {
            Id = new Guid(),
            Name = "testOrganization1",
            Achievements = { }
        };

        _context.Achievements.Add(achievement);
        _context.SaveChanges();








        //Запрещаем отслеживание (разрываем связи с БД)
        _context.ChangeTracker.Clear();
    }

    public TestHelper(int i)
    {
        var contextOptions = new DbContextOptionsBuilder<Context>()
                .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Test")
                .Options;

        _context = new Context(contextOptions);

        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();


        var portfolioId = new Guid("83f1fe49-f701-4497-b02f-08dc00ca2fa6");
        Portfolio portfolio = new Portfolio
        {
            Id = portfolioId,
            UserName = "Pavel",
            Achievements = { }
        };

        _context.Portfolios.Add(portfolio);



        var orgId = new Guid("83f1fe49-f701-5555-b02f-08dc00ca2fa6");
        Organization organization = new Organization
        {
            Id = orgId,
            Name = "Yandex",
            Achievements = { }
        };

        _context.Organizations.Add(organization);
        _context.SaveChanges();


        //Запрещаем отслеживание (разрываем связи с БД)
        _context.ChangeTracker.Clear();
    }    
        

    public AchievementRepository AchievementRepository
    {
        get
        {
            return new AchievementRepository(_context);
        }
    }

    public PortfolioRepository PortfolioRepository
    {
        get
        {
            return new PortfolioRepository(_context);
        }
    }

    public OrganizationsRepository OrganizationsRepository
    {
        get
        {
            return new OrganizationsRepository(_context);
        }
    }
}