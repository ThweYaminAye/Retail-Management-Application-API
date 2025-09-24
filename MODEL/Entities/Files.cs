using System;
using MODEL.CommonConfig;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class Files : Common
    {
        
        [Key]
        public Guid Id { get; set; }
        public string? FileName { get; set; }
        public string? FileUrl { get; set; }
        
    }
}
