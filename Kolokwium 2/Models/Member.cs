using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium_2.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public int OrganizationId { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string? MemberNickName { get; set; }

        public virtual ICollection<MemberShip> Memberships { get; set; }
        public virtual Organization Organization { get;  set; }
    }
}
