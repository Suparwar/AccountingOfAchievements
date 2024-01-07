using AccountingOfAchievements.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingOfAchievements.Domain.DTO;

public class PortfolioDTOMapper
{
    public static Portfolio ToEntity(PortfolioDTO portfolioDTO)
    {
        var portfolio = new Portfolio();
        portfolio.Id = portfolioDTO.Id;
        portfolio.UserName = portfolioDTO.UserName;

        return portfolio;
    }

    public static PortfolioDTO ToDto(Portfolio portfolio)
    {
        var portfolioDTO = new PortfolioDTO();
        portfolioDTO.Id = portfolio.Id;
        portfolioDTO.UserName = portfolio.UserName;
        portfolioDTO.AchievementsDTO = AchievementDTOMapper.ToDto(portfolio.Achievements);

        return portfolioDTO;
    }

    public static List<PortfolioDTO> ToDto(List<Portfolio> portfolios)
    {
        var portfolioDTO = new List<PortfolioDTO>();
        foreach(var portfolio in portfolios)
        {
            portfolioDTO.Add(ToDto(portfolio));
        }

        return portfolioDTO;
    }
}
