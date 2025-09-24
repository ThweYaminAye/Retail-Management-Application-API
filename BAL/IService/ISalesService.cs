using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL.DTO;
using MODEL.Entities;

namespace BAL.IService
{
    public interface ISalesService
    {
        Task<Dictionary<Guid, int>> BuyProducts(Guid id, int Quantity);
        Task<IEnumerable<Sales>> ViewSalesReport();
        Task<Dictionary<string, decimal>> TotalSummary();
        Task<Object> SalesByDate(string inputdate);
    }
}
