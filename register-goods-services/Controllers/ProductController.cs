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

        public List<Product> GetProductsAsyncFiltered(
            int pageNumber,
            string? name,
            int? organisation_id,
            float[]? price,
            int pageSize = 10
        )
        {
            var result = _database.Table<Product>();

            if(!name.Equals(null))
                result.Where(e => (e.Name == name));

            if (!organisation_id.Equals(null))
                result.Where(e => (e.Organisation_id == organisation_id));

            if (!price.Equals(null))
                result.Where(
                    e => (e.Price >= price[0])
                    && (e.Price <= price[1])
                );
            return GetPage(result.ToListAsync().Result, pageNumber, pageSize);
        }
    }
}
