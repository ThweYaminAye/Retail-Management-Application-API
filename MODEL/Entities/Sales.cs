using MODEL.CommonConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Entities
{
    public class Sales : Common
    {
        [Key]
        public Guid SalesID { get; set; }
        public Guid? ProductID { get; set; }
        public string? ProductName { get; set; } 
        public int? QuantitySold { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? TotalProfit { get; set; }

       
    }
}
