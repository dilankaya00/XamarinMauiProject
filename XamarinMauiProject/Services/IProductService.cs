using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinMauiProject.Models;

namespace XamarinMauiProject.Services
{
    public interface IProductService
    {
        Task<List<ProductsModel>> GetAllProduct();
        Task<int> AddProduct(ProductsModel products);
        Task<int> UpdateProduct(ProductsModel products);
        Task<int> DeleteProduct(ProductsModel products);
        Task<ProductsModel> GetProductByID(int ProductID);
    }
}
