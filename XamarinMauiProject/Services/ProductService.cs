using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinMauiProject.Models;

namespace XamarinMauiProject.Services
{
    public class ProductService : IProductService
    {

        private SQLiteAsyncConnection _dbConnection;
        public ProductService()
        {
            SetUpDb();
        }
        private async void SetUpDb()
        {

            if (_dbConnection == null)
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Product.db3");
                _dbConnection = new SQLiteAsyncConnection(dbPath);
                await _dbConnection.CreateTableAsync<ProductsModel>();
            }
        }
        public async Task<int> AddProduct(ProductsModel products)
        {
            return await _dbConnection.InsertAsync(products);
        }

        public async Task<int> DeleteProduct(ProductsModel products)
        {
            return await _dbConnection.DeleteAsync(products);
        }

        public async Task<List<ProductsModel>> GetAllProduct()
        {
            return await _dbConnection.Table<ProductsModel>().ToListAsync();
        }

        public async Task<int> UpdateProduct(ProductsModel products)
        {
            return await _dbConnection.UpdateAsync(products);
        }

        public async Task<ProductsModel> GetProductByID(int ProductID)
        {
            var products = await _dbConnection.QueryAsync<ProductsModel>($"Select * From {nameof(ProductsModel)} where ProductID={ProductID} ");
            return products.FirstOrDefault();
        }
    }
}
