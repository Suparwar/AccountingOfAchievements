

namespace AccountingOfAchievements.Domain.DTO;

public class OrganizationDTOMapper
{
    public static Organization ToEntity(OrganizationDTO organizationDTO)
    {
        var organization = new Organization();
        organization.Id = organizationDTO.Id;
        organization.Name = organizationDTO.Name;

        return organization;
    }

    public static OrganizationDTO ToDto(Organization organization)
    {
        var organizationDto = new OrganizationDTO();
        organizationDto.Id = organization.Id;
        organizationDto.Name = organization.Name;

        return organizationDto;
    }

    public static List<OrganizationDTO> ToDto(List<Organization> organizations)
    {
        var organizationsDto = new List<OrganizationDTO>();
        foreach(var organization in organizations)
        {
            organizationsDto.Add(ToDto(organization));
        }

        return organizationsDto;
    }
}
