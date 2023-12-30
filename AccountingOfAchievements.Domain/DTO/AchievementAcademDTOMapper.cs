using AccountingOfAchievements.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOfAchievements.Domain.DTO;

public class AchievementAcademDTOMapper
{
    public static AcademicAchievement ToEntity(AchievementAcademDTO achievementDTO)
    {
        var achievement = new AcademicAchievement();
        achievement.Id = achievementDTO.Id;
        achievement.DateOfReceiving = achievementDTO.DateOfReceiving;

        return achievement;
    }

    public static AchievementAcademDTO ToDto(AcademicAchievement achievement)
    {
        var achievementDTO = new AchievementAcademDTO();
        achievementDTO.Id = achievement.Id;
        achievementDTO.PortfolioName = achievement.Portfolio.UserName;
        achievementDTO.PortfilioId = achievement.Portfolio.Id;
        achievementDTO.DateOfReceiving = achievement.DateOfReceiving;
        achievementDTO.OrganizationName = achievement.IssuedFrom.Name;
        achievementDTO.OrganizationId = achievement.IssuedFrom.Id;

        achievementDTO.AcademArea = achievement.AcademArea;
        achievementDTO.AreaStage = achievement.AreaStage;

        return achievementDTO;
    }

    public static List<AchievementAcademDTO> ToDto(List<AcademicAchievement> achievements)
    {
        var achievementsDTO = new List<AchievementAcademDTO>();
        foreach (var achievemet in achievements)
        {
            achievementsDTO.Add(ToDto(achievemet));
        }

        return achievementsDTO;
    }
}
