using AccountingOfAchievements.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOfAchievements.Domain.DTO;

public class AchievementArtDTOMapper
{
    public static ArtAchievement ToEntity(AchievementArtDTO achievementDTO)
    {
        var achievement = new ArtAchievement();
        achievement.Id = achievementDTO.Id;
        achievement.DateOfReceiving = achievementDTO.DateOfReceiving;

        achievement.NameOfCompet = achievementDTO.NameOfCompet;
        achievement.AreaStage = achievementDTO.AreaStage;

        return achievement;
    }

    public static AchievementArtDTO ToDto(ArtAchievement achievement)
    {
        var achievementDTO = new AchievementArtDTO();
        achievementDTO.Id = achievement.Id;
        achievementDTO.PortfolioName = achievement.Portfolio.UserName;
        achievementDTO.PortfilioId = achievement.Portfolio.Id;
        achievementDTO.DateOfReceiving = achievement.DateOfReceiving;
        achievementDTO.OrganizationName = achievement.IssuedFrom.Name;
        achievementDTO.OrganizationId = achievement.IssuedFrom.Id;

        achievementDTO.AreaStage = achievement.AreaStage;
        achievementDTO.NameOfCompet = achievement.NameOfCompet;

        return achievementDTO;
    }

    public static List<AchievementArtDTO> ToDto(List<ArtAchievement> achievements)
    {
        var achievementsDTO = new List<AchievementArtDTO>();
        foreach (var achievemet in achievements)
        {
            achievementsDTO.Add(ToDto(achievemet));
        }

        return achievementsDTO;
    }
}
