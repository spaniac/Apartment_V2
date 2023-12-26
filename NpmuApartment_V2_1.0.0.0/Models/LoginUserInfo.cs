using System;

namespace NpmuApartment_V2.Models
{
    public class LoginUserInfo
    {
        public string Id { get; set; }
        public string PermissionCode { get; set; }
        public string PermissionName { get; set; }
        public DateTime LoginDtm { get; set; }
    }
}