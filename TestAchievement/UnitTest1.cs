using AccountingOfAchievements.Domain.Model;
using AccountingOfAchievements.Domain;
using AccountingOfAchievements.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;
using AccountingOfAchievements.Infrastructure.Repository;
using Microsoft.Identity.Client;

namespace TestAchievement;

public class UnitTest1
{
    [Fact]
    public void baseCreated()
    {
        var testHelper = new TestHelper();
        var AchievRep = testHelper.AchievementRepository;

        Assert.Equal(1, 1);
    }


    [Fact]
    public async void TestAdd()
    {
        var testHelper = new TestHelper();
        var AchievRep = testHelper.AchievementRepository;

        var achievement = new Achievement();
        var achivId = new Guid("3a8dc8a9-fe58-4483-c227-08dc00d18a77");
        achievement.Id = achivId;

        var portfolio = new Portfolio();
        achievement.Portfolio = portfolio;
        
        achievement.DateOfReceiving = new DateTime();

        var organization = new Organization();
        achievement.IssuedFrom = organization;
    
        
        var achiv2 = await AchievRep.AddAsync(achievement, portfolio.Id, organization.Id);
        AchievRep.ChangeTrackerClear();

        Assert.True(AchievRep.GetAllAsync().Result.Count == 2);
        Assert.Equal("3a8dc8a9-fe58-4483-c227-08dc00d18a77", achievement.Id.ToString());
        Assert.Equal(achievement.DateOfReceiving, AchievRep.GetByIdAsync(achivId).Result.DateOfReceiving);
    }



    [Fact]
    public void base2Created()
    {
        var testHelper = new TestHelper(1);
        var AchievRep = testHelper.AchievementRepository;
        var PortRep = testHelper.PortfolioRepository;
        var OrgRep = testHelper.OrganizationsRepository;

        Assert.Equal(1, 1);
    }

    [Fact]
    public void OrgAndPortfolioExist()
    {
        var testHelper = new TestHelper(1);
        var PortRep = testHelper.PortfolioRepository;
        var OrgRep = testHelper.OrganizationsRepository;

        Assert.True(PortRep.GetAllAsync().Result.Count == 1);
        Assert.True(OrgRep.GetAllAsync().Result.Count == 1);
    }

    [Fact]
    public async void TestAddInOrganizationAndPortfolio()
    {
        var testHelper = new TestHelper(1);
        var AchievRep = testHelper.AchievementRepository;


        var portfolioId = new Guid("83f1fe49-f701-4497-b02f-08dc00ca2fa6");
        var orgId = new Guid("83f1fe49-f701-5555-b02f-08dc00ca2fa6");

        var achivId = new Guid("3a8dc8a9-fe58-4483-c228-08dc00d18a77");
        var achievement = new Achievement
        {
            Id = achivId,
            DateOfReceiving = new DateTime(),
        };


        AchievRep.AddAsync(achievement, portfolioId, orgId);
        var achiv2 = AchievRep.GetByIdAsync(achivId).Result;
        AchievRep.ChangeTrackerClear();


        Assert.Equal("3a8dc8a9-fe58-4483-c228-08dc00d18a77", achievement.Id.ToString());
        Assert.Equal(achievement, achiv2);
        //Assert.Equal(achievement, AchievRep.GetByIdAsync(achivId).Result);
    }
}


/* var testHelper = new TestHelper();
        var AchievRep = testHelper.AchievementRepository;
        var PortRep = testHelper.PortfolioRepository;
        var OrgRep = testHelper.OrganizationsRepository;


        var achievement = new Achievement();
        var achivId = new Guid();
        achievement.Id = achivId;

        var portfolioId = new Guid();
        var portfolio = new Portfolio
        {
            Id = portfolioId,
            UserName = "testUser2",
            Achievements = { }
        };
        achievement.Portfolio = portfolio;
        
        achievement.DateOfReceiving = new DateTime();

        var orgId = new Guid();
        achievement.IssuedFrom = new Organization
        {
            Id = orgId,
            Name = "testOrganization2",
            Achievements = { }
        };
*/