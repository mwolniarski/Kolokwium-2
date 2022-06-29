using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium_2.Models
{
    public class MemberShip
    {
        public int MemberId { get; set; }
        public int TeamId { get; set; }
        public DateTime MembershipDate { get; set; }

        public virtual Member Member { get; set; }
        public virtual Team Team { get;  set; }
    }
}
