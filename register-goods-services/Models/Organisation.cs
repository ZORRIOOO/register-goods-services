using System;
namespace registergoodsservices
{
    public enum OrganisationTypes : uint
    {
        shelter = 10,
        transportOrganization = 20,
        veterinaryClinicMinitipal = 31,
        veterinaryClinicPrivate = 32,
        veterinaryClinicGoverment = 33,
        sellingAnimalsGoodsOrg = 40
    }

    public class Organisation : Model
    {
        public string Name { get; set; }
        public int Address { get; set; }
        public int Inn { get; set; }
        public int Kpp { get; set; }
        public OrganisationTypes OrganisationType { get; set; }
    }
}
