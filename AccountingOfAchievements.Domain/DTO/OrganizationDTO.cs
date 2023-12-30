using AccountingOfAchievements.Domain.Model;

namespace AccountingOfAchievements.Domain.DTO;

public class OrganizationDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
}
