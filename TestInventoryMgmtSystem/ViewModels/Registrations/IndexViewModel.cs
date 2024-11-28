using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace TestInventoryMgmtSystem.ViewModels.Registrations
{
    public class IndexViewModel
    {
        [ValidateNever]
        public string Id { get; set; }

        [Display(Name ="Firstname")]
        public string FirstName { get; set; }

        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        public string Email { get; set; }

        [Display(Name = "Cellphone")]
        public string CellphoneNr { get; set; }
        public string Role { get; set; }
    }
}
