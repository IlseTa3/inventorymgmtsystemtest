using Microsoft.AspNetCore.Identity;

namespace TestInventoryMgmtSystem.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string CellPhoneNr { get; set; }
    }
}
