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
        portfolioDTO.UserName = portfolioDTO.UserName;

        return portfolioDTO;
    }
}
