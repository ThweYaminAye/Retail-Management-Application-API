using BAL.IService;
using MODEL.DTO;
using MODEL.Entities;
using MODEL.CommonConfig;
using REPOSITORY.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BAL.Service
{
    public class ProductsService : IProductsService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appsettings;

        public ProductsService(IUnitOfWork unitOfWork, AppSettings appsettings)
        {

            _unitOfWork = unitOfWork;
            _appsettings = appsettings;
        }

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            var data = await _unitOfWork.Products.GetByCondition(x => x.ActiveFlag == true);
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            return data;
        }

        public async Task<Products> GetPrdouctById(Guid id)
        {
            var data = await _unitOfWork.Products.GetById(id);
            if (data == null)
            {
                throw new AbandonedMutexException(nameof(data));
            }
            return data;
        }

        public async Task<Products> DeleteProductById(Guid id)
        {
            var data = await _unitOfWork.Products.GetById(id);
            data.ActiveFlag = false;
            _unitOfWork.Products.Update(data);
            await _unitOfWork.SaveChangesAsync();
            return data;
        }

        public async Task<Products> AddNewPrdouct(ProductDTO pd)
        {
            var data = new Products()
            {
                ProductID = new Guid(),
                ProductName = pd.ProductName,
                Stock = pd.Stock,
                SellingPrice = pd.SellingPrice,
                ProfitPerItem = pd.ProfitPerItem,
            };

            if (data == null)
            {
                throw new Exception("Enter the required product's fields!!!");
            }
            await _unitOfWork.Products.Add(data);
            await _unitOfWork.SaveChangesAsync();
            return data;
        }

        public async Task<Products> UpdateProductById(Guid id, ProductDTO dto)
        {
            var data = await _unitOfWork.Products.GetById(id);
            if (data == null)
            {
                throw new Exception("Product doesn't found");
            }
            data.ProductName = dto.ProductName;
            data.Stock = dto.Stock;
            data.SellingPrice = dto.SellingPrice;
            data.ProfitPerItem = dto.ProfitPerItem;
            data.UpdatedBy = "Admin";
            data.UpdatedDate = DateTime.UtcNow;

            _unitOfWork.Products.Update(data);
            await _unitOfWork.SaveChangesAsync();
            return data;
        }

        
        
    }
}
