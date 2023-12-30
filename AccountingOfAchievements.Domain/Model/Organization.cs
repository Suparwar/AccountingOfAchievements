using AccountingOfAchievements.Domain.Model;

namespace AccountingOfAchievements.Domain;

public class Organization
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public List<Achievement> Achievements { get; set; } = new List<Achievement>();
    public void AddAchivement(Achievement achiev)
    {
        Achievements.Add(achiev);
    }
    public void RemoveAchievement(Achievement achiev)
    {
        Achievements.Remove(achiev);
    }
}