using AccountingOfAchievements.Domain.Model;

namespace AccountingOfAchievements.Domain;

public class Organization
{
    public string OgrName { get; set; } = String.Empty;
    public Guid OrganizationID { get; set; }
    public List<Achievement> Achievements { get; set; } = new List<Achievement>();
    public void AddAchivement(Achievement achiev)
    {
        Achievements.Add(achiev);
    }
    public void removeAchievement(Achievement achiev)
    {
        Achievements.Remove(achiev);
    }
}