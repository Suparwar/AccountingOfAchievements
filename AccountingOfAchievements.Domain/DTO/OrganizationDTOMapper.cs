

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
}
