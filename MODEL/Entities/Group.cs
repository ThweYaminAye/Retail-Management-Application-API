using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class Group
    {
        [Key]
        public int GroupID { get; set; }

        public string? UGroupID { get; set; }

        public string? GroupName { get; set; }

        public string? CreateBy { get; set; } = "Admin";

        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;

        public string? UpdateBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public bool? ActiveFlag { get; set; } = true;

        public int? RoleID { get; set; }

        public Guid? CompanyId { get; set; }
    }
}
