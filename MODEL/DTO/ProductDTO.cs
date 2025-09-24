using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.DTO
{
    public class ProductDTO
    {
        public string? ProductName { get; set; }
        public int? Stock { get; set; }
        public decimal? SellingPrice { get; set; }
        public decimal? ProfitPerItem { get; set; }
    }
}
