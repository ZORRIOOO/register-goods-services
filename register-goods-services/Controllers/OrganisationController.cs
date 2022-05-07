using System;
using System.Collections.Generic;

namespace registergoodsservices.Controllers
{
    public class OrganisationController: Controller<Organisation>
    {
        public OrganisationController(string dbPath) : base(dbPath)
        {

        }

        public List<Organisation> GetOrganisationsAsyncFiltered(
            int pageNumber,
            string? name,
            OrganisationTypes? organisationType,
            int? inn,
            int pageSize = 10
        )
        {
            var result = _database.Table<Organisation>();

            if (!name.Equals(null))
                result.Where(e => e.Name == name);

            if (!organisationType.Equals(null))
                result.Where(e => e.OrganisationType == organisationType);

            if (!inn.Equals(null))
                result.Where(e => e.Inn == inn);


            return GetPage(result.ToListAsync().Result, pageNumber, pageSize);
        }
    }
}
