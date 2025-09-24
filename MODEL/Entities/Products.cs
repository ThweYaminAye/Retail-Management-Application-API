using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL.CommonConfig;

namespace MODEL.Entities
{
    public class Products : Common
    {
        [Key]
        public Guid ProductID { get; set; }
        public string? ProductName { get; set; }
        public int? Stock { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? ProfitPerItem { get; set; }

    }
}
