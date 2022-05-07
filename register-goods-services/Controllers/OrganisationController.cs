using System;
using System.Collections.Generic;

namespace registergoodsservices.Controllers
{
    public class OrganisationController: Controller<Organisation>
    {
        public OrganisationController(string dbPath) : base(dbPath)
        {

        }

        public List<Organisation> GetProductsAsyncFiltered(
            int pageNumber,
            string? name,
            OrganisationTypes? organisation_type,
            int? inn,
            int pageSize = 10
        )
        {
            var result = _database.Table<Organisation>();

            if (!name.Equals(null))
                result.Where(e => e.Name == name);

            if (!organisation_type.Equals(null))
                result.Where(e => e.Organisation_type == organisation_type);

            if (!inn.Equals(null))
                result.Where(e => e.Inn == inn);


            return GetPage(result.ToListAsync().Result, pageNumber, pageSize);
        }
    }
}
