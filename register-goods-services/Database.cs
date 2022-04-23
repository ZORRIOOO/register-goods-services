using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace registergoodsservices
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Product>();
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return _database.Table<Product>().ToListAsync();
        }

        public Task<Product> GetProductAsync(Product product)
        {
            return _database.Table<Product>().ElementAtAsync(product.ID);
        }

        public Task<List<Product>> GetProductsAsyncFiltered(string name)
        {
            return _database.Table<Product>()
                .Where(e => (e.Name == name))
                .ToListAsync();
        }

        public Task<List<Product>> GetProductsAsyncFiltered(string name, int organisation_id)
        {
            return _database.Table<Product>()
                .Where(e => (e.Name == name) && (e.Organisation_id == organisation_id))
                .ToListAsync();
        }

        public Task<int> SaveProductAsync(Product product)
        {
            return _database.InsertAsync(product);
        }

        public void DeleteProductasync(Product product)
        {
            _database.DeleteAsync(product);
        }
    }
}
