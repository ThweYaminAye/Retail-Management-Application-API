using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class MemberInfo
    {
        [Key]
        public Guid MemberID { get; set; }

        public long? IDCard { get; set; }

        public string? Prefix { get; set; }

        public string? FirstName { get; set; }

        public string? FullName { get; set; }

        public string? LastName { get; set; }

        public string? Mobile { get; set; }

        public string? EMail { get; set; }

        public string? Department { get; set; }

        public string? Levels { get; set; }

        public string? PathImage { get; set; }

        public Guid? CompanyId { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public string CreateBy { get; set; } = "Admin";

        public DateTime? UpdateDate { get; set; }

        public string? UpdateBy { get; set; }

        public bool ActiveFlag { get; set; } = true;

        public string? Gender { get; set; }

        public string? ContactName { get; set; }
    }
}
