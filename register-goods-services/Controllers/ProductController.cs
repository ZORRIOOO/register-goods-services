using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace registergoodsservices.Controllers
{
    public class ProductController : Controller<Product>
    {
        public ProductController(string dbPath) : base(dbPath)
        {
            
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
                .Where(
                    e =>
                        (e.Name == name)
                        && (e.Organisation_id == organisation_id)
                )
                .ToListAsync();
        }

        public Task<List<Product>> GetProductsAsyncFiltered(
            string name,
            int organisation_id,
            float minPrice,
            float maxPrice
        ){
            return _database.Table<Product>()
                .Where(
                    e =>
                        (e.Name == name)
                        && (e.Organisation_id == organisation_id)
                        && (e.Price >= minPrice)
                        && (e.Price >= organisation_id)
                )
                .ToListAsync();
        }
    }
}
