namespace Kolokwium_2.Models.DTO
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }

        public OrganizationDto OrganizationDto { get; set; }
    }
}
