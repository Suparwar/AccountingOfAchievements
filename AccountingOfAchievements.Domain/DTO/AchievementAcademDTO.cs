using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOfAchievements.Domain.DTO;

public class AchievementAcademDTO
{
    public string AcademArea { get; set; }
    public string AreaStage { get; set; }

    public Guid Id { get; set; }
    public string PortfolioName { get; set; }
    public Guid PortfilioId { get; set; }
    public DateTime DateOfReceiving { get; set; }
    public string OrganizationName { get; set; }
    public Guid OrganizationId { get; set; }
}
