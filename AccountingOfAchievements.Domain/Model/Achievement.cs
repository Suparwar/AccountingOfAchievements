namespace AccountingOfAchievements.Domain.Model;

public class Achievement
{
    public Guid Id { get; set; }
    public Portfolio Portfolio { get; set; }
    public DateTime DateOfReceiving { get; set; }
    public Organization IssuedFrom { get; set; }
}

public class SportAchievement:Achievement
{
    public string KindOfSport { get; set; }
    public string TeamName { get; set; }
}

public class AcademicAchievement: Achievement
{
    public string AcademArea { get; set; }
    public string AreaStage { get; set; }
}

public class ArtAchievement: Achievement
{
    public string NameOfCompet { get; set; }
    public string AreaStage { get; set; }
}