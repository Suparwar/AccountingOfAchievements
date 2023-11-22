using AccountingOfAchievements.Domain.Model;

namespace AccountingOfAchievements.Domain.Model;

public class Portfolio
{
    public Guid PortfolioId { get; set; }
    public string UserName { get; set; } = String.Empty;
    public List<Achievement> PersonalPortfolio { get; set; } = new List<Achievement>();

    public void AddPersonalAchiev(Achievement achiev)
    {
        PersonalPortfolio.Add(achiev);
    }

    public void RemovePersonalAchiv(Achievement achiev)
    {
        PersonalPortfolio.Remove(achiev);
    }
}
