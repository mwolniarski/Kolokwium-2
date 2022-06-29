using System.Collections.Generic;

namespace Kolokwium_2.Models.DTO
{
    public class OrganizationDto
    {
        public string OrganizationName { get; set; }

        public ICollection<MemberDto> Members { get; set; }
    }
}
