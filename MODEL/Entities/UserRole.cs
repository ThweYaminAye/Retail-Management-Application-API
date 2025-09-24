using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class UserRole
    {
        [Key]
        public int UserRoleID { get; set; }
        public string? RoleCode { get; set; }

        public string? RoleName { get; set; }

        public Guid? CompanyID { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;

        public string? CreateBy { get; set; } = "Admin";

        public DateTime? UpdateDate { get; set; }

        public string? UpdateBy { get; set; }

        public bool? ActiveFlag { get; set; } = true;
    }
}
