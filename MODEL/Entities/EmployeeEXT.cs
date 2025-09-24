using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class EmployeeEXT
    {
        [Key]
        public Guid EmployeeID { get; set; }

        public string? EmpID { get; set; }

        public int? SalaryID { get; set; }

        public int? UserID { get; set; }

        public Guid? MemberID { get; set; }

        public int? SupervisorID { get; set; }

        public DateTime? StartWorkDate { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public string CreateBy { get; set; } = "Admin";

        public DateTime? UpdateDate { get; set; }

        public string? UpdateBy { get; set; }

        public bool? ActiveFlag { get; set; } = true;

        public Guid? CompanyId { get; set; }
    }
}
