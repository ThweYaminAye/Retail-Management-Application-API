using MODEL.DTO;
using MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public interface IProductsService
    {
        Task<IEnumerable<Products>> GetAllProducts();
        Task<Products> GetPrdouctById(Guid id);
        Task<Products> DeleteProductById(Guid id);
        Task<Products> AddNewPrdouct(ProductDTO pd);
        Task<Products> UpdateProductById(Guid id, ProductDTO dto);

        //Task<Dictionary<Guid, int>> BuyProducts(Guid id, int Quantity);
    }
}
