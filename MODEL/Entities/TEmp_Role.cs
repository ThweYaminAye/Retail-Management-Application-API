using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class TEmp_Role
    {
        [Key]
        public int TEmp_Role_ID { get; set; }

        public int? EmployeeID { get; set; }

        public int? RoleID { get; set; }

        public string? CreateBy { get; set; } = "Admin";

        public string? UpdateBy { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdateDate { get; set; }

        public bool? ActiveFlag { get; set; } = true;
    }
}
