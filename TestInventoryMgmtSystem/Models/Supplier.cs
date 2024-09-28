﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace TestInventoryMgmtSystem.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Display(Name = "Name Supplier")]
        public string NameSupplier { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Municipality { get; set; }
        public string Country { get; set; }
        public string VatNr { get; set; }
        
        public string PhoneNr { get; set; }
        public string Email { get; set; }

        //1 supplier has many products

        
        public virtual ICollection<Product> Products { get; set; }
    }
}
