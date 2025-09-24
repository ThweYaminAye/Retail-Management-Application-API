using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.CommonConfig
{
    public class Common
    {
        public string? CreatedBy { get; set; } = "Admin";
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
        public string? UpdatedBy { get;set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? ActiveFlag { get; set; } = true; 
        
    }
}
