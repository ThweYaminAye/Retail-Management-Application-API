using BAL.IService;
using MODEL.CommonConfig;
using MODEL.Entities;
using REPOSITORY.UnitOfWork;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using Microsoft.SqlServer.Server;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
using Microsoft.Identity.Client;

namespace BAL.Service
{
    public class SalesService : ISalesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appsettings;
        private readonly DataContext _dbcontext;

        public SalesService(IUnitOfWork unitOfWork, AppSettings appsettings, DataContext dbcontext)
        {

            _unitOfWork = unitOfWork;
            _appsettings = appsettings;
            _dbcontext = dbcontext;
        }

        public async Task<Dictionary<Guid,int>> BuyProducts(Guid id, int Quantity)
        {
            Dictionary<Guid, int> cart = new Dictionary<Guid, int>();

            var data = await _unitOfWork.Products.GetById(id);
            if(cart.ContainsKey(id))
            {
                cart[id] += Quantity;
            }
            cart[id] = Quantity;
            if(data == null)
            {
                throw new Exception("Selected product id is not found");
            }
            data.Stock -= Quantity;
            data.UpdatedBy = "Admin";
            data.UpdatedDate = DateTime.UtcNow;
         
            _unitOfWork.Products.Update(data);

            var totalProfit = data.ProfitPerItem * Quantity;

            var saleRecord = new Sales()
            {
                SalesID = Guid.NewGuid(), 
                ProductID = data.ProductID,
                ProductName = data.ProductName,
                QuantitySold = Quantity,
                SellingPrice = data.SellingPrice, 
                TotalProfit = totalProfit,
                CreatedBy = "Admin",
                CreatedDate = DateTime.UtcNow
            };

            if(saleRecord == null)
            {
                throw new Exception("Cannot record sale items");
            }
            await _unitOfWork.Sales.Add(saleRecord);
            await _unitOfWork.SaveChangesAsync();


            return cart;
                
               
        }

        public async Task<IEnumerable<Sales>> ViewSalesReport()
        {
            var data = await _unitOfWork.Sales.GetByCondition(x => x.ActiveFlag == true);
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            return data;
        }

        public async Task<Dictionary<string, decimal>> TotalSummary()
        {
            decimal totalRevenue = 0;
            decimal totalProfit = 0;
            Dictionary<string, decimal> result = new Dictionary<string, decimal>();
            var query = from sale in _dbcontext.Sales
                        select new { revenue = (sale.SellingPrice * sale.QuantitySold ?? 0),  unitprofit = sale.TotalProfit ?? 0 };
            foreach( var item in query)
            {
                totalRevenue += item.revenue;
                totalProfit += item.unitprofit;

            }
            result["TotalRevenue"] = totalRevenue;
            result["TotalProfit"] = totalProfit;
            return result;

        }
        
        public async Task<Object> SalesByDate(string inputdate)
        {
            decimal totalRevenue = 0;
            decimal totalProfit = 0;
            var data = await _unitOfWork.Sales.GetByCondition(x => x.ActiveFlag == true);

            DateTime parsedDate;

            if (!DateTime.TryParse(inputdate, out parsedDate))
            {
                return new { message = "Invalid date format" };
            }

            var query = from sale in data
                        where sale.CreatedDate.HasValue &&
                              sale.CreatedDate.Value.Date == parsedDate.Date
                        select new
                        {

                            salesID = sale.SalesID,
                            productID = sale.ProductID,
                            productName = sale.ProductName,
                            QuantitySold = sale.QuantitySold,
                            SellingPrice = sale.SellingPrice,
                            TotalProfit = sale.TotalProfit,
                            revenue = (sale.SellingPrice * sale.QuantitySold ?? 0),

                        };
            var salesList = query.ToList();

            foreach (var item in salesList) {
                totalRevenue += item.revenue;
                totalProfit += (decimal)item.TotalProfit;
            }

            return new{  salesList, totalRevenue, totalProfit  };
      
        }
    

        

    }
}
