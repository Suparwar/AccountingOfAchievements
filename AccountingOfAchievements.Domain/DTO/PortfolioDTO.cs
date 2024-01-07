using AccountingOfAchievements.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOfAchievements.Domain.DTO;

public class PortfolioDTO
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = String.Empty;

    public List<AchievementDTO> AchievementsDTO { get; set; } = new List<AchievementDTO>();
}
