using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class TEmp_Group
    {
        [Key]
        public int TEmp_Group_ID { get; set; }

        public int? EmployeeID { get; set; }

        public int? GroupID { get; set; }

        public string? CreateBy { get; set; } = "Admin";

        public string? UpdateBy { get; set; }

        public DateTime? CreateDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdateDate { get; set; }

        public bool? ActiveFlag { get; set; } = true;
    }
}
