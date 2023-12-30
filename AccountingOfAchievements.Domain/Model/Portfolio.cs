using AccountingOfAchievements.Domain.Model;

namespace AccountingOfAchievements.Domain.Model;

public class Portfolio
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = String.Empty;
    public List<Achievement> Achievements { get; set; } = new List<Achievement>();

    public void AddPersonalAchiev(Achievement achiev)
    {
        Achievements.Add(achiev);
    }

    public void RemovePersonalAchiv(Achievement achiev)
    {
        Achievements.Remove(achiev);
    }
}
