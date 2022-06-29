using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium_2.Models
{
    public class Organization
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationDomain { get; set; }

        public virtual ICollection<Member> Members { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
