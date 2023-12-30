using AccountingOfAchievements.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOfAchievements.Domain.DTO;

public class AchievementSportDTOMapper
{
    public static Achievement ToEntity(AchievementSportDTO achievementDTO)
    {
        var achievement = new SportAchievement();
        achievement.Id = achievementDTO.Id;
        achievement.DateOfReceiving = achievementDTO.DateOfReceiving;

        achievement.KindOfSport = achievementDTO.KindOfSport;
        achievement.TeamName = achievementDTO.TeamName;

        return achievement;
    }

    public static AchievementSportDTO ToDto(SportAchievement achievement)
    {
        var achievementDTO = new AchievementSportDTO();
        achievementDTO.Id = achievement.Id;
        achievementDTO.PortfolioName = achievement.Portfolio.UserName;
        achievementDTO.PortfilioId = achievement.Portfolio.Id;
        achievementDTO.DateOfReceiving = achievement.DateOfReceiving;
        achievementDTO.OrganizationName = achievement.IssuedFrom.Name;
        achievementDTO.OrganizationId = achievement.IssuedFrom.Id;

        achievementDTO.TeamName = achievement.TeamName;
        achievementDTO.KindOfSport = achievement.KindOfSport;

        return achievementDTO;
    }

    public static List<AchievementSportDTO> ToDto(List<SportAchievement> achievements)
    {
        var achievementsDTO = new List<AchievementSportDTO>();
        foreach(var achievemet in achievements)
        {
            achievementsDTO.Add(ToDto(achievemet));
        }

        return achievementsDTO;
    }
}
