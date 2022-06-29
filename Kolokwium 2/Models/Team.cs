using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium_2.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public int OrganizationId { get; set; }
        public string TeamName { get; set; }
        public string? TeamDescription { get; set; }

        public virtual ICollection<MemberShip> MemberShips { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
