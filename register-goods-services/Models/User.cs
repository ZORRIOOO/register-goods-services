using System;
namespace registergoodsservices.Models
{
    public enum UserTypes : uint
    {
        user = 10,
        transportOrganization = 20,
        veterinaryClinicMinitipal = 31,
        veterinaryClinicPrivate = 32,
        veterinaryClinicGoverment = 33,
        sellingAnimalsGoodsOrg = 40
    }

    public class User: Model
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserTypes UserType { get; set; }
        public uint OrgainsationId { get; set; }

    }
}
