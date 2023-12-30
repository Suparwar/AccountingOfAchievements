using AccountingOfAchievements.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOfAchievements.Domain.DTO;

public class AchievementDTOMapper
{
    public static AchievementDTO ToDto(Achievement achievement)
    {
        var achievementDTO = new AchievementDTO();
        achievementDTO.Id = achievement.Id;
        achievementDTO.PortfolioName = achievement.Portfolio.UserName;
        achievementDTO.PortfilioId = achievement.Portfolio.Id;
        achievementDTO.DateOfReceiving = achievement.DateOfReceiving;
        achievementDTO.OrganizationName = achievement.IssuedFrom.Name;
        achievementDTO.OrganizationId = achievement.IssuedFrom.Id;

        achievementDTO.typeAchievement = achievement.GetType().ToString();

        return achievementDTO;
    }

    public static List<AchievementDTO> ToDto(List<Achievement> achievements)
    {
        var achievementsDTO = new List<AchievementDTO>();
        foreach (var achievemet in achievements)
        {
            achievementsDTO.Add(ToDto(achievemet));
        }

        return achievementsDTO;
    }
}
